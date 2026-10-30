using vubox.blocks;
using vubox.engine.blockconfig;
using vubox.entity;

namespace vubox.engine;

public static class BlockLoader
{
    private static Dictionary<string, BlockConfig> configs = [];

    public static Dictionary<string, BlockConfig> Configs { get => configs; set => configs = value; }

    public static void LoadBlock(BlockConfig config)
    {
        string id = config.Name;
        if (Configs.ContainsKey(id)) throw new Exception($"block by identifier '{id}' is already registered!");

        Configs[id] = config;
    }

    public static Block CreateBlock(string id, int globalX, int globalY)
    {
        return GetConfig(id).Finish(globalX, globalY);
    }

    public static BlockConfig GetConfig(string id)
    {
        if (Configs.TryGetValue(id, out var bc)) return bc;
        throw new Exception($"block by identifier '{id}' is not registered!");
    }

    public static void LoadDefaults()
    {
        LoadBlock(new BlockConfig("dirt", "default:dirt")
            .Display("dirt"));
        LoadBlock(new BlockConfig("stone", "default:stone")
            .Display("stone"));
        LoadBlock(new BlockConfig("gravel", "default:gravel")
            .Display("gravel"));
        LoadBlock(new BlockConfig("planks", "default:planks")
            .Display("planks"));
    }
}
