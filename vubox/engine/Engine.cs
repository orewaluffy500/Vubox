using vubox.asset;
using vubox.blocks;
using Raylib_cs;
using vubox.modding;
using vubox.events;
using System.Diagnostics.Tracing;
using Lua;

namespace vubox.engine;

public class Engine
{
    public World World;
    public LuaEnviron LuaEnv;
    public CallbackManager CallbackManager;
    public EngineEventManager EventManager;

    private float timeTillTick = Globals.TICK_DELAY;
    public bool IsCycling = false;

    public Engine(string title)
    {
        Raylib.SetTraceLogLevel(TraceLogLevel.Error);
        Raylib.InitWindow(Globals.WIDTH, Globals.HEIGHT, title);
        Raylib.SetTargetFPS(Globals.MAX_FPS);

        Globals.engine = this;
        World = new(this);
        LuaEnv = new(this);
        CallbackManager = new(this);
        EventManager = new(this);
        
        Logger.Info("succesful construction of core components");
    }

    public void Load()
    {
        Logger.Info("succesfully loaded default blocks");
        World.Load();
        Logger.Info("initialized world");
        LuaEnv.Load();
        Logger.Info("initialized modding environment");
    }

    public void Update()
    {
        IsCycling = false;
        timeTillTick -= Globals.DELTA_TIME;
        if (timeTillTick <= 0f)
        {
            timeTillTick = Globals.TICK_DELAY;
            IsCycling = true;
            
            // Fire cycle event
            EventManager.Invoke(EventManager.Cycle, new NoCallbackArgs());
        }

        World.Update(Globals.DELTA_TIME);

        // Check for input
        CheckInput();
    }

    public void CheckInput()
    {
        // Check keys first
        if (EventManager.Key.Array is not null)
        {
            foreach (var key in Enum.GetValues<KeyboardKey>())
            {
                if (key != KeyboardKey.Null && Raylib.IsKeyPressed(key))
                {
                    EventManager.Invoke(EventManager.Key, new InputCallbackArgs((int)key));
                }
            }
        }

        // Check mouse buttons
        if (EventManager.Mouse.Array is not null)
        {
            foreach (var mouse in Enum.GetValues<MouseButton>())
            {
                if (Raylib.IsMouseButtonPressed(mouse))
                {
                    EventManager.Invoke(EventManager.Mouse, new InputCallbackArgs((int)mouse));
                }
            }
        }
    }

    public void Draw()
    {
        Raylib.ClearBackground(new(20, 20, 30));
        World.Draw();

        Raylib.DrawText($"{Globals.CURRENT_FPS}/{Globals.MAX_FPS}", 0, 0, 14, new(210, 210, 210));
    }

    public void Close()
    {
        // Fire close event
        EventManager.Invoke(EventManager.Close, new NoCallbackArgs());

        World.Unload();
        Logger.Info("unloaded world");
        
        TextureLoader.Unload();
        Logger.Info("unloaded textures");
        
        Raylib.CloseWindow();
        Logger.Info("closed raylib environment");

        Logger.Info("closing...");
    }

    public void Start()
    {
        Load();

        while (!Raylib.WindowShouldClose())
        {
            Update();
            Raylib.BeginDrawing();
            Draw();
            Raylib.EndDrawing();
        }
    }














    private static void DrawUnknownTexture(int x, int y, int w, int h, float ox, float oy, int angle)
    {
        Raylib.DrawRectanglePro(new(x, y, w, h), new(w * ox, h * oy), angle, Color.Black);
    }

    public static void DrawTexture(Texture2D? texture, int x, int y, int w, int h, float originX = 0f, float originY = 0f, int angle = 0)
    {
        if (texture is null) { DrawUnknownTexture(x, y, w, h, originX, originY, angle); return; }
        Raylib.DrawTexturePro(
            texture.Value,
            new(0, 0, texture.Value.Width, texture.Value.Height),
            new(x, y, w, h),
            new(w * originX, h * originY),
            angle,
            Color.White
        );
    }

    public static void DrawTexture(Texture2D? texture, Rectangle source, Rectangle dest, float originX = 0f, float originY = 0f, int angle = 0)
    {
        if (texture is null){ DrawUnknownTexture((int)dest.X, (int)dest.Y, (int)dest.Width, (int)dest.Height, originX, originY, angle); return; }
        Rectangle sourcefinal = new(source.X, source.Y, source.Width == 0 ? texture.Value.Width : source.Width, source.Height == 0 ? texture.Value.Height : source.Height);
        
        Raylib.DrawTexturePro(
            texture.Value,
            sourcefinal,
            dest,
            new(dest.Width * originX, dest.Height * originY),
            angle,
            Color.White
        );
    }

    public static void DrawTexture(int textureId, Rectangle source, Rectangle dest, float originX = 0f, float originY = 0f, int angle = 0)
    {
        Texture2D? texture = TextureLoader.GetTextureUnsure(textureId);
        DrawTexture(texture, source, dest, originX, originY);
    }

    public static void DrawTexture(int textureId, int x, int y, int w, int h, float originX = 0f, float originY = 0f, int angle = 0)
    {
        Texture2D? texture = TextureLoader.GetTextureUnsure(textureId);
        DrawTexture(texture, x, y, w, h, originX, originY);
    }
}







public struct EngineEventManager(Engine engine) : IEventManager
{
    public LazyCallbackArray Cycle, Key, Mouse, Close;

    public readonly void Invoke<TArgs>(LazyCallbackArray array, TArgs args) where TArgs: struct, ICallbackParams
    {
        DefaultEventManager.Invoke(engine, array, args);
    }

    public void On(string name, int id)
    {
        if (name == "cycle") Cycle.Get()[Cycle.Top] = id;
        if (name == "key")   Key.Get()[Key.Top] = id;
        if (name == "mouse") Mouse.Get()[Mouse.Top] = id;
        if (name == "close") Close.Get()[Close.Top] = id;
        Logger.Error($"unknown event name: {name}");
    }
}