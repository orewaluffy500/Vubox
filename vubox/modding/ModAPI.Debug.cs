using Lua;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_Debug
{
    [LuaMember("log")]
    public void Log(string message)
    {
        Console.WriteLine($"[MOD] (LOG) :: {message}");
    }

    [LuaMember("error")]
    public void Err(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[MOD] (ERROR) :: {message}");
        Console.ResetColor();
    }

    [LuaMember("warn")]
    public void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[MOD] (WARN) :: {message}");
        Console.ResetColor();
    }
}