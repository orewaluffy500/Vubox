using Raylib_cs;

namespace vubox.engine;

public static class Globals
{
    public static int WIDTH => 960;
    public static int HEIGHT => 640;
    public static int MAX_FPS => 60;
    public static int MAX_BLOCKS_PER_TICK => 5;
    public static int CURRENT_FPS => Raylib.GetFPS();

    public static int CHUNK_SIZE => 16;
    public static int CELL_SIZE => 16;
    public static int RENDER_DISTANCE => 32;
    public static float DELTA_TIME => Raylib.GetFrameTime();
    public static int UNIQUE_ID => field++;
    public static int TICK_SPEED => 20;
    public static float TICK_DELAY => 1f / TICK_SPEED;

    public static Random Random => new();
    public static Engine Engine => engine!;
    internal static Engine? engine = null; // guarenteed non-null

}