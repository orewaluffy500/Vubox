using Lua;
using vubox.engine;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_World(World world)
{
    World _world = world;

    [LuaMember("playerY")]
    public int PlayerX { get => _world.Player.X; }
    [LuaMember("playerX")]
    public int PlayerY { get => _world.Player.Y; }

    [LuaMember("movePlayer")]
    public void MovePlayer(int dx, int dy)
    {
        _world.Player.Movement.X += dx;
        _world.Player.Movement.Y += dy;
    }

    [LuaMember("tpPlayer")]
    public void TeleportPlayer(int x, int y)
    {
        _world.Player.X = x;
        _world.Player.Y = y;
    }

    [LuaMember("place")]
    public void Place(string id, int x, int y, bool replace = false)
    {
        _world.Place(id, x, y, replace);
    }

    [LuaMember("destroy")]
    public void Destroy(int x, int y)
    {
        _world.Destroy(x, y);
    }

    [LuaMember("on")]
    public void On(string eventName, int callbackId)
    {
        _world.EventManager.On(eventName, callbackId);
    }
}