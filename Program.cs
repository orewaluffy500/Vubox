using vubox.engine;
using Lua;
using Lua.Standard;

Engine engine = new("Vubox (BETA)");

LuaState state = LuaState.Create();

try {
    engine.Start();
} catch (Exception e)
{
    if (args.Contains("-vv"))
    {
        Logger.Error($"Error!\n -- {e}");
    } else
    {
        Logger.Error($"Error!\n -- {e.Message} {e.InnerException?.Message}");
    }
} finally
{
    engine.Close();
}