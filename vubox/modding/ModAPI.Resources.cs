using Lua;
using vubox.asset;

namespace vubox.modding;

[LuaObject]
public partial class ModAPI_Resources
{
    [LuaMember("block")]
    public ModAPI_BlockConfig Block(string name)
    {
        return new(name);
    }

    [LuaMember("texture")]
    public int LoadTexture(string path)
    {
        return TextureLoader.Load(path);
    }
}