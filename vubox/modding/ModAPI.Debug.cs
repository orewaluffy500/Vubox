using Lua;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_Debug
{
    [LuaMember]
    public void log(string message)
    {
        Console.WriteLine($"[MOD] (LOG) :: {message}");
    }

    [LuaMember]
    public void err(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[MOD] (ERROR) :: {message}");
        Console.ResetColor();
    }

    [LuaMember]
    public void warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[MOD] (WARN) :: {message}");
        Console.ResetColor();
    }
}