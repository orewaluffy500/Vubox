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

public struct InputCallbackArgs(int input) : ICallbackParams
{
    public int Count => 1;

    public void Push(LuaEnviron env)
    {
        env.Push(input);
    }
}

public struct BlockCallbackArgs(ModAPI_Block block) : ICallbackParams
{
    public int Count => 1;

    public void Push(LuaEnviron env)
    {
        env.Push(block);
    }
}