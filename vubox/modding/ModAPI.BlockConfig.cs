using Lua;
using vubox.engine;
using vubox.engine.blockconfig;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_BlockConfig(string _name)
{
    [LuaMember]
    public string name { get; } = _name;
    [LuaMember]
    public string displayName = _name;
    [LuaMember]
    public string textureName = "";

    [LuaMember]
    public void finalize()
    {
        BlockConfig config = new(textureName, name);
        config.Display(displayName);
        BlockLoader.LoadBlock(config);
    }
}