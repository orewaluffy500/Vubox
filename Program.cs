using vubox.engine;
using Lua;
using Lua.Standard;

Engine engine = new("Vubox (BETA)");

LuaState state = LuaState.Create();

try {
    engine.StartAsync();
} catch (Exception e)
{
    if (args.Contains("-vv"))
    {
        Console.WriteLine($"Error!\n{e}");
    } else
    {
        Console.WriteLine($"Error!\n{e.Message} {e.InnerException?.Message}");
    }
} finally
{
    engine.CloseAsync();
}