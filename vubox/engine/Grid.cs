using vubox.blocks;
using vubox.entity;

namespace vubox.engine;


public class Grid(Engine engine) : IObject
{
    public Engine Engine = engine;
    public Dictionary<long, Chunk> Chunks = [];
    public List<Chunk> NearestChunks = [];
    public static long Key(int x, int y) => ((long)x << 32) | (uint)y;
    // get the coords of the chunk containing this cell
    public static Tuple<int, int> ToChunk(int x, int y) =>
    new(
        (int)Math.Floor((double)x / Globals.CHUNK_SIZE),
        (int)Math.Floor((double)y / Globals.CHUNK_SIZE)
    );
    // get the coords of this cell inside a chunk
    public static Tuple<int, int> ToLocal(int x, int y) => new(((x % Globals.CHUNK_SIZE) + Globals.CHUNK_SIZE) % Globals.CHUNK_SIZE, ((y % Globals.CHUNK_SIZE) + Globals.CHUNK_SIZE) % Globals.CHUNK_SIZE);

    public void Draw()
    {
        foreach (Chunk chunk in NearestChunks)
        {
            chunk.Draw();
        }
    }

    public void Load()
    {
    }

    public void Unload()
    {
        foreach (Chunk chunk in NearestChunks)
        {
            chunk.Unload();
        }
    }

    public void Update(float dt)
    {
        // Find nearest chunks
        NearestChunks.Clear();
        var (originX, originY) = ToChunk(Engine.World.Player.X, Engine.World.Player.Y);

        for (int i = originY - Globals.RENDER_DISTANCE; i < originY + Globals.RENDER_DISTANCE; i++)
        {
            for (int j = originX - Globals.RENDER_DISTANCE; j < originX + Globals.RENDER_DISTANCE; j++)
            {
                if (!Chunks.TryGetValue(Key(j, i), out var chunk)) continue;
                NearestChunks.Add(chunk);
                chunk.Update(dt);
            }
        }
    }

    /// gets a chunk but initializes a new one if the target doesn't exist
    public Chunk GetChunk(int chunkX, int chunkY)
    {
        var key = Key(chunkX, chunkY);
        if (Chunks.TryGetValue(key, out var chunk)) return chunk;

        Chunk newChunk = new(chunkX, chunkY);
        newChunk.Load();
        Chunks[key] = newChunk;
        return newChunk;
    }

    public Chunk GetChunkFromGlobalCoords(int globalX, int globalY)
    {
        var (x, y) = ToChunk(globalX, globalY);
        return GetChunk(x, y);
    }

    public void Set(int localX, int localY, Block block)
    {
        Chunk chunk = GetChunkFromGlobalCoords(block.X, block.Y);
        chunk.Set(localX, localY, block);
    }

    public void Clear(int globalX, int globalY)
    {
        Chunk chunk = GetChunkFromGlobalCoords(globalX, globalY);
        var (localX, localY) = Grid.ToLocal(globalX, globalY);
        chunk.Clear(localX, localY);
    }
    
    public Block Get(int globalX, int globalY)
    {
        Chunk chunk = GetChunkFromGlobalCoords(globalX, globalY);
        var (localX, localY) = ToLocal(globalX, globalY);
        return chunk.Get(localX, localY);
    }
}