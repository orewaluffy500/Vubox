using vubox.asset;
using vubox.blocks;
using vubox.engine.blockconfig;

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
        Logger.Info($"registered block: {config.DisplayName} ({config.Name})");
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
        LoadBlock(new BlockConfig(TextureLoader.Load("textures/dirt.png"), "default:dirt"){ DisplayName = "dirt" });
        LoadBlock(new BlockConfig(TextureLoader.Load("textures/stone.png"), "default:stone"){ DisplayName = "stone" });
        LoadBlock(new BlockConfig(TextureLoader.Load("textures/gravel.png"), "default:gravel"){ DisplayName = "gravel" });
        LoadBlock(new BlockConfig(TextureLoader.Load("textures/planks.png"), "default:planks"){ DisplayName = "planks" });
    }
}
