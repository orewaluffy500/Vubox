using Lua;
using vubox.asset;
using vubox.engine;

namespace vubox.modding;

[LuaObject]
public partial class ModAPI_Resources(Engine engine)
{
    Engine _engine = engine;
    [LuaMember("block")]
    public ModAPI_BlockConfig Block(string name)
    {
        return new(_engine, name);
    }

    [LuaMember("texture")]
    public int LoadTexture(string path)
    {
        return TextureLoader.Load(path);
    }
}