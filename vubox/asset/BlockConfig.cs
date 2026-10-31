using vubox.blocks;

namespace vubox.engine.blockconfig;

public class BlockConfig(int texture, string name)
{
    public string Name { get; private set; } = name;
    public int Texture { get; private set; } = texture;
    public string DisplayName { get; private set; } = name;
    public BlockConfig Display(string v){ DisplayName = v; return this; }

    public Block Finish(int x, int y)
    {
        Block b = new(Globals.Engine!)
        {
            X = x,
            Y = y,
            Name = Name,
            TextureId = Texture
        };
        return b;
    }
}