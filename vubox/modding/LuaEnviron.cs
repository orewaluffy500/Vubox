using Lua;
using Lua.Standard;
using vubox.engine;

namespace vubox.modding;

public class LuaEnviron(Engine engine)
{
    public LuaState State = LuaState.Create();
    public Engine Engine = engine;
    public Dictionary<string, LuaFunction> CallbackMap = [];

    public void Draw()
    {
    }

    public void Load()
    {
        LoadAPIs();
        LoadMods();
    }

    public void LoadAPIs()
    {
        State.Environment["game"] = new ModAPI(Engine);
    }

    public void LoadMods()
    {
        State.OpenStandardLibraries();

        string directory = "GameData/mods";
        if (!Directory.Exists(directory)) return;

        foreach (string file in Directory.EnumerateFiles(directory))
        {
            if (!File.Exists(file)) continue;
            string contents = File.ReadAllText(file);

            Syncer.Sync(State.DoStringAsync(contents));
        }
    }

    public void Unload()
    {
    }

    public void Update(float dt)
    {
    }


    public void Push(LuaValue v)
    {
        State.Push(v);
    }

    public void Call(int base_)
    {
        Syncer.Sync(State.CallAsync(funcIndex: base_, returnBase: base_));
    }

    public int StackCount() => State.Stack.Count;
}