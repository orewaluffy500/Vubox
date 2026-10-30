using vubox.asset;
using vubox.engine;
using Raylib_cs;

namespace vubox.blocks;

public class Block(Engine engine) : IObject
{
    public Engine Engine = engine;
    public int X = 0, Y = 0;
    public int Frame = 0, Row = 0;
    
    int oldTexture = -1;
    Texture2D? texture = null;
    public int TextureName = -1;
    public string Name = "";

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
    }

    public void Unload()
    {
    }

    public void Update(float dt)
    {
        if (oldTexture != TextureName) ReloadTexture();
    }

    internal void ReloadTexture()
    {
        texture = TextureLoader.GetTextureUnsure(TextureName);
        oldTexture = TextureName;
    }

    public void Interact()
    {
    }
}