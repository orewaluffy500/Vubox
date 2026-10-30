using Lua;

namespace vubox.engine;

public class CallbackManager(Engine engine)
{
    public Engine Engine = engine;
    List<LuaFunction> _callbacks = [];

    public LuaFunction GetCallback(int id)
    {
        if (id < 0 || id > _callbacks.Count)
        {
            return new LuaFunction((_, _) => new(0));
        }

        return _callbacks[id - 1];
    }

    public int CreateCallback(LuaFunction function)
    {
        _callbacks.Add(function);
        return _callbacks.Count;
    }
}