using System.Numerics;
using vubox.blocks;
using vubox.engine;

namespace vubox.entity;

public class Entity
{
    public int X = 0, Y = 0;
    public int UniqueID = Globals.UNIQUE_ID;
    internal Vector2 VisualPosition = new(), Movement = new();
    internal int LERP_SPEED = 32;

    public virtual void Draw()
    {
    }

    public virtual void Load()
    {
    }

    public virtual void Unload()
    {
    }

    public virtual void Update(float dt)
    {
        if (X - VisualPosition.X < 0.01f) VisualPosition.X = X; 
        if (Y - VisualPosition.Y < 0.01f) VisualPosition.Y = Y; 
        VisualPosition.X = JsaMath.Lerp(VisualPosition.X, X, Math.Clamp(LERP_SPEED * dt, 0f, 1f));
        VisualPosition.Y = JsaMath.Lerp(VisualPosition.Y, Y, Math.Clamp(LERP_SPEED * dt, 0f, 1f));
    }

    public bool Move(bool collision = true)
    {
        int dx = (int)Movement.X, dy = (int)Movement.Y;
        if (!collision)
        {
            X += dx;
            Y += dy;
            return true;
        }

        Block? destination = Globals.Engine!.World.GetBlock(X + dx, Y + dy);
        // add checks for collision later
        if (destination is not null) return false;

        X += dx;
        Y += dy;

        return true;
    }
}