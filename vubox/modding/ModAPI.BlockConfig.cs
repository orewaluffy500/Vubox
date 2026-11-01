using Lua;
using vubox.asset;
using vubox.engine;
using vubox.engine.blockconfig;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_BlockConfig(Engine engine, string _name)
{
    Engine _engine = engine;

    [LuaMember("name")]
    public string Name { get; } = _name;
    [LuaMember("display")]
    public string DisplayName = _name;
    [LuaMember("texture")]
    public int Texture = -1;
    [LuaMember("asleep")]
    public bool Asleep = true;

    [LuaMember("commit")]
    public void Finish()
    {
        BlockConfig config = new(Texture, Name)
        {
            DisplayName = DisplayName,
            Asleep = Asleep
        };
        BlockLoader.LoadBlock(config);
    }

    [LuaMember("on")]
    public void On(string eventName, int callbackId)
    {
        BlockEvents.GetManager(Name).On(eventName, callbackId);
    }
}