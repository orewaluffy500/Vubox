using Lua;
using vubox.engine;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_Debug
{
    [LuaMember("log")]
    public void Log(string message)
    {
        Logger.Log(ConsoleColor.Green, "mod log", message);
    }

    [LuaMember("error")]
    public void Err(string message)
    {
        Logger.Log(ConsoleColor.Red, "mod err", message);
    }

    [LuaMember("warn")]
    public void Warn(string message)
    {
        Logger.Log(ConsoleColor.Yellow, "mod warn", message);
    }
}