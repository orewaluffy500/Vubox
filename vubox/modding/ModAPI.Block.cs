using Lua;
using vubox.blocks;
using vubox.engine;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_Block(World world, Block block)
{
    World _world = world;
    Block _block = block;

    [LuaMember("x")]
    public int X => _block.X;
    [LuaMember("y")]
    public int Y => _block.Y;
    [LuaMember("name")]
    public string Name => _block.Name;
    [LuaMember("texture")]
    public int TextureId { get => _block.TextureId; set => _block.TextureId = value; }
}