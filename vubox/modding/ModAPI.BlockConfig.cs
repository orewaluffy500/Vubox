using Lua;
using vubox.engine;
using vubox.engine.blockconfig;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_BlockConfig(string _name)
{
    [LuaMember("name")]
    public string Name { get; } = _name;
    [LuaMember("display")]
    public string DisplayName = _name;
    [LuaMember("texture")]
    public int Texture = -1;

    [LuaMember("finish")]
    public void Finish()
    {
        BlockConfig config = new(Texture, Name);
        config.Display(DisplayName);
        BlockLoader.LoadBlock(config);
    }
}