using vubox.blocks;

namespace vubox.engine.blockconfig;

public class BlockConfig(int texture, string name)
{
    public string Name { get; set; } = name;
    public int Texture { get; set; } = texture;
    public string DisplayName { get; set; } = name;
    public bool Asleep { get; set; } = true;

    public Block Finish(int x, int y)
    {
        Block b = new(Globals.Engine, Name)
        {
            X = x,
            Y = y,
            TextureId = Texture,
            Asleep = Asleep
        };
        return b;
    }
}