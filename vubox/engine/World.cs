using vubox.blocks;
using vubox.entity;
using Raylib_cs;
using vubox.events;

namespace vubox.engine;

public class World : IObject
{
    public Engine Engine;
    public Grid Grid;
    public Player Player;
    public WorldEventManager EventManager;

    public World(Engine engine)
    {
        Engine = engine;
        Grid = new(Engine);
        Player = new(Engine);
        EventManager = new(this);
    }

    public void Draw()
    {
        Raylib.BeginMode2D(Player.Camera);
        Grid.Draw();
        Player.Draw();
        Raylib.EndMode2D();
    }

    public void Load()
    {
        Player.Load();
    }

    public void Unload()
    {
        Player.Unload();
        Grid.Unload();
    }

    public void Update(float dt)
    {
        Player.Update(dt);
        Grid.Update(dt);
    }

    public Block? Place(string name, int globalX, int globalY, bool replace = false)
    {
        if (!replace)
        {
            var b = GetBlock(globalX, globalY);
            if (b is not null) return null;
        }
        // Get chunk-local coordinates
        var (localX, localY) = Grid.ToLocal(globalX, globalY);
        
        // Create block and set it
        Block block = BlockLoader.CreateBlock(name, globalX, globalY);
        Grid.Set(localX, localY, block);
        
        // Load block and refresh texture
        block.Load();
        block.ReloadTexture();

        // Fire global block events
        EventManager.Invoke(EventManager.Placed, new NoCallbackArgs());

        return block;
    }

    public void Destroy(int globalX, int globalY)
    {
        // Get block
        var block = Grid.Get(globalX, globalY);
        if (block is null) return;

        // Fire global block events
        EventManager.Invoke(EventManager.Broken, new NoCallbackArgs());

        // Call block unload and clear it
        block.Unload();
        Grid.Clear(globalX, globalY);
    }

    public Block? GetBlock(int globalX, int globalY)
    {
        return Grid.Get(globalX, globalY);
    }

}


public struct WorldEventManager(World world) : IEventManager
{
    public LazyCallbackArray Placed, Broken;

    public async readonly void Invoke<TArgs>(LazyCallbackArray array, TArgs args) where TArgs : struct, ICallbackParams
    {
        DefaultEventManager.Invoke(world.Engine, array, args);
    }

    public void On(string name, int id)
    {
        if (name == "place") Placed.Get()[Placed.Top] = id;
        if (name == "break") Broken.Get()[Broken.Top] = id;
    }
}