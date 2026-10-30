using vubox.modding;

namespace vubox.events;

public interface ICallbackParams
{
    int Count { get; }
    void Push(LuaEnviron env);
}

public struct NoCallbackArgs : ICallbackParams
{
    public int Count => 0;

    public void Push(LuaEnviron env)
    {
    }
}
