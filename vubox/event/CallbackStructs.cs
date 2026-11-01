using Microsoft.VisualBasic;
using vubox.engine;

namespace vubox.events;

public struct LazyCallbackArray
{
    public int[]? Array = null;
    public int Top { get => field + 1 < Get().Length ? field++ : field; }

    public LazyCallbackArray(){}
    public int[] Get() => Array ??= new int[512];
}

public interface IEventManager
{
    void On(string name, int id);
    void Invoke<TArgs>(LazyCallbackArray array, TArgs args) where TArgs: struct, ICallbackParams;
}

public struct DefaultEventManager
{
    // use TArgs for the argument struct type to avoid boxing.
    public static void Invoke<TArgs>(Engine engine, LazyCallbackArray array, TArgs args) where TArgs: struct, ICallbackParams
    {
        // skip if no events
        if (array.Array is null) return;

        // go through each id
        foreach (var id in array.Get())
        {
            if (id == 0) return; // 0 is the end point

            // get function
            var func = engine.CallbackManager.GetCallback(id);

            // get the base index for where the function is pushed
            var baseIndex = engine.LuaEnv.StackCount();
            
            engine.LuaEnv.Push(func);   // push function
            args.Push(engine.LuaEnv);   // push function argument
            engine.LuaEnv.Call(baseIndex); // call from base index
        }
    }
}