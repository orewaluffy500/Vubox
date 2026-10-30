using vubox.asset;
using vubox.engine;
using Raylib_cs;

namespace vubox.blocks;

public class Block(Engine engine) : IObject
{
    public Engine Engine = engine;
    public int X = 0, Y = 0;
    public int Frame = 0, Row = 0;
    
    string oldTexture = "";
    Texture2D? texture = null;
    public string TextureName = "";
    public string Name = "";

    public void Draw()
    {
        Engine.DrawTexture(
            texture,
            new(Frame * Globals.CELL_SIZE, Row * Globals.CELL_SIZE, Globals.CELL_SIZE, Globals.CELL_SIZE),
            new(X * Globals.CELL_SIZE, Y * Globals.CELL_SIZE, Globals.CELL_SIZE, Globals.CELL_SIZE),
            0f, 0f, 0
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