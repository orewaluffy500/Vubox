using vubox.asset;
using vubox.engine;
using Raylib_cs;
using vubox.events;

namespace vubox.blocks;

public class Block(Engine engine, string name) : IObject
{
    public Engine Engine = engine;
    public int X = 0, Y = 0;
    public int Frame = 0, Row = 0;
    
    int oldTexture = -1;
    Texture2D? texture = null;
    public int TextureId = -1;
    public string Name = name;
    public bool Asleep = true;

    BlockEventManager _eventManager = BlockEvents.GetManager(name);

    public void Draw()
    {
        // we add cell-size / 2 to the pixel coords so it aligns with the grid
        Engine.DrawTexture(
            texture,
            new(Frame * Globals.CELL_SIZE, Row * Globals.CELL_SIZE, Globals.CELL_SIZE, Globals.CELL_SIZE),
            new(X * Globals.CELL_SIZE + Globals.CELL_SIZE / 2, Y * Globals.CELL_SIZE + Globals.CELL_SIZE / 2, Globals.CELL_SIZE, Globals.CELL_SIZE),
            0.5f, 0.5f, 0
        );
    }

    public void Load()
    {
        if (Asleep) return;
        _eventManager.Invoke(_eventManager.Place, new NoCallbackArgs());
    }

    public void Unload()
    {
        if (Asleep) return;
    }

    public void Update(float dt)
    {
        if (oldTexture != TextureId) ReloadTexture();
    }

    public void Cycle()
    {
        if (Asleep) return;   
    }

    internal void ReloadTexture()
    {
        texture = TextureLoader.GetTextureUnsure(TextureId);
        oldTexture = TextureId;
    }

    public void Interact()
    {
        if (Asleep) return;   
    }
}



public class BlockEventManager(Engine engine) : IEventManager
{
    public LazyCallbackArray Place, Break, Interact, Cycle;
    public void Invoke<TArgs>(LazyCallbackArray array, TArgs args) where TArgs : struct, ICallbackParams
    {
        DefaultEventManager.Invoke(engine, array, args);
    }

    public void On(string name, int id)
    {
        if (name == "place") Place.Get()[Place.Top] = id;
        if (name == "cycle") Cycle.Get()[Cycle.Top] = id;
        if (name == "break") Break.Get()[Break.Top] = id;
        if (name == "interact") Interact.Get()[Interact.Top] = id;
    }
}