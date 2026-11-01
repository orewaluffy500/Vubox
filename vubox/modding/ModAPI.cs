using Lua;
using vubox.engine;

namespace vubox.modding;

[LuaObject]
public partial class ModAPI(Engine engine)
{
    Engine _engine = engine;

    [LuaMember("debug")]
    public ModAPI_Debug Debug { get; } = new();
    [LuaMember("world")]
    public ModAPI_World World { get; } = new(engine.World);
    [LuaMember("res")]
    public ModAPI_Resources Resources { get; } = new(engine);

    [LuaMember("callback")]
    public int Callback(LuaFunction function)
    {
        return _engine.CallbackManager.CreateCallback(function);
    }

    [LuaMember("on")]
    public void On(string name, int id)
    {
        _engine.EventManager.On(name, id);
    }
}