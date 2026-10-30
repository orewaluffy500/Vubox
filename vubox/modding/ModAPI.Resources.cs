using Lua;

namespace vubox.modding;

[LuaObject]
public partial class ModAPI_Resources
{
    [LuaMember]
    public ModAPI_BlockConfig block(string name)
    {
        return new(name);
    }
}