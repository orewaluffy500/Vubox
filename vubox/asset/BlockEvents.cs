using vubox.blocks;
using vubox.engine;

namespace vubox.asset;


public class BlockEvents
{
    public static Dictionary<string, BlockEventManager> Events = [];

    public static BlockEventManager GetManager(string blockName)
    {
        if (!Events.ContainsKey(blockName)) Events[blockName] = new(Globals.Engine);
        return Events[blockName];
    }
}