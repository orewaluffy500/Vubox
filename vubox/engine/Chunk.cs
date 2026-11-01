using vubox.blocks;
using vubox.entity;
using Raylib_cs;

namespace vubox.engine;


public class Chunk(int x, int y) : IObject
{
    public Block[] Blocks = new Block[Globals.CHUNK_SIZE * Globals.CHUNK_SIZE];
    public int X = x, Y = y;

    public void Draw()
    {
        int fullSize = Globals.CHUNK_SIZE * Globals.CELL_SIZE;
        Raylib.DrawRectangleLinesEx(new(X * fullSize, Y * fullSize, fullSize, fullSize), 1, new(90, 90, 90, 191));
        // Console.WriteLine($"{X} {Y}");
        foreach (Block block in Blocks){
            if (block is null) continue;

            block.Draw();
        }
    }

    public void Load()
    {
    }

    public void Unload()
    {
        foreach (Block block in Blocks)
        {
            if (block is null) continue;
            block.Unload();
        }
    }

    public void Update(float dt)
    {
        if (!Globals.Engine.IsCycling) return;

        foreach (Block block in Blocks)
        {
            if (block is null) continue;
            block.Cycle();
        }
    }

    public void Set(int localX, int localY, Block block)
    {
        if (localX < 0 || localX >= Globals.CHUNK_SIZE) throw new Exception("out of bounds x coordinate!");
        if (localY < 0 || localY >= Globals.CHUNK_SIZE) throw new Exception("out of bounds y coordinate!"); // TODO : replace with my own error
        Blocks[localY * Globals.CHUNK_SIZE + localX] = block;
    }

    public void Clear(int localX, int localY)
    {
        if (localX < 0 || localX >= Globals.CHUNK_SIZE) throw new Exception("out of bounds x coordinate!");
        if (localY < 0 || localY >= Globals.CHUNK_SIZE) throw new Exception("out of bounds y coordinate!"); // TODO : replace with my own error
        Array.Clear(Blocks, localY * Globals.CHUNK_SIZE + localX, 1);
    }
    public Block Get(int localX, int localY)
    {
        if (localX < 0 || localX >= Globals.CHUNK_SIZE) throw new Exception("out of bounds x coordinate!");
        if (localY < 0 || localY >= Globals.CHUNK_SIZE) throw new Exception("out of bounds y coordinate!"); // TODO : replace with my own error
        return Blocks[localY * Globals.CHUNK_SIZE + localX];
    }
}