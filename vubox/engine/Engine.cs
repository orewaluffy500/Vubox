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
    public bool Ticking = false;

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
    }

    public void LoadAsync()
    {
        BlockLoader.LoadDefaults();
        World.Load();
        LuaEnv.Load();
    }

    public void Update()
    {
        Ticking = false;
        timeTillTick -= Globals.DELTA_TIME;
        if (timeTillTick <= 0f)
        {
            timeTillTick = Globals.TICK_DELAY;
            Ticking = true;
            
            // Fire cycle event
            EventManager.Invoke(EventManager.Cycle, new NoCallbackArgs());
        }

        World.Update(Globals.DELTA_TIME);
    }

    public void Draw()
    {
        Raylib.ClearBackground(new(20, 20, 30));
        World.Draw();

        Raylib.DrawText($"{Globals.CURRENT_FPS}/{Globals.MAX_FPS}", 0, 0, 14, new(210, 210, 210));
    }

    public void CloseAsync()
    {
        // Fire close event
        EventManager.Invoke(EventManager.Close, new NoCallbackArgs());

        World.Unload();
        TextureLoader.Unload();
        Raylib.CloseWindow();
    }

    public void StartAsync()
    {
        LoadAsync();

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
    }
}