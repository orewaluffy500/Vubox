using Lua;
using vubox.engine;

namespace vubox.modding;

[LuaObject]
public partial class ModAPI(Engine engine)
{
    Engine _engine = engine;

    [LuaMember]
    public ModAPI_Debug debug { get; } = new();
    [LuaMember]
    public ModAPI_World world { get; } = new(engine.World);


    [LuaMember]
    public int callback(LuaFunction function)
    {
        return _engine.CallbackManager.CreateCallback(function);
    }

    [LuaMember]
    public void on(string name, int id)
    {
        _engine.EventManager.On(name, id);
    }
}