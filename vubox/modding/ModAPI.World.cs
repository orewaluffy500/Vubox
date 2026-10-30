using Lua;
using vubox.engine;

namespace vubox.modding;


[LuaObject]
public partial class ModAPI_World(World world)
{
    World _world = world;

    [LuaMember]
    public int player_x { get => _world.Player.X; }
    [LuaMember]
    public int player_y { get => _world.Player.Y; }

    [LuaMember]
    public void move_player(int dx, int dy)
    {
        _world.Player.Movement.X += dx;
        _world.Player.Movement.Y += dy;
    }

    [LuaMember]
    public void tp_player(int x, int y)
    {
        _world.Player.X = x;
        _world.Player.Y = y;
    }

    [LuaMember]
    public void place(string id, int x, int y, bool replace = false)
    {
        _world.PlaceAsync(id, x, y, replace);
    }

    [LuaMember]
    public void destroy(int x, int y)
    {
        _world.DestroyAsync(x, y);
    }

    [LuaMember]
    public void on(string eventName, int callbackId)
    {
        _world.EventManager.On(eventName, callbackId);
    }
}