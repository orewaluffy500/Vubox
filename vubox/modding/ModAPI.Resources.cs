using Lua;

namespace vubox.modding;

[LuaObject]
public partial class ModAPI_Resources
{
    [LuaMember("block")]
    public ModAPI_BlockConfig Block(string name)
    {
        return new(name);
    }
}