using System.Numerics;
using vubox.engine;
using Raylib_cs;

namespace vubox.entity;

public class Player : Entity
{
    public Engine Engine;
    public float Timer = 0f;
    public static readonly float MAX_MOVE_DELAY = 0.1f;
    Hand hand;
    float timeSinceMove = MAX_MOVE_DELAY;

    public Camera2D Camera = new(new(0, 0), new(Globals.WIDTH / 2, Globals.HEIGHT / 2), 0f, 1.5f);

    public Player(Engine engine){ hand = new(this); Engine = engine; }

    public override void Load()
    {
        hand.Load();
    }

    public override void Unload()
    {
        hand.Unload();
    }

    public override void Draw()
    {
        Raylib.DrawRectangle(
            (int)(VisualPosition.X * Globals.CELL_SIZE) + 1,
            (int)(VisualPosition.Y * Globals.CELL_SIZE) + 1,
            Globals.CELL_SIZE - 2,
            Globals.CELL_SIZE - 2,
            new(255, 80, 80)
        );
        hand.Draw();
    }

    public override void Update(float dt)
    {
        // 1. get pixel visual coords
        // 2. lerp them to (CameraPos - (ScreenSize / CameraZoom / 2))
        //      this lerps the camera's target to the visual position offset by half the screen width relative to the current camera zoom.

        Camera.Target.X = JsaMath.Lerp(Camera.Target.X, (VisualPosition.X * Globals.CELL_SIZE) - (Globals.WIDTH / Camera.Zoom / 2), dt * (LERP_SPEED * 0.75f));
        Camera.Target.Y = JsaMath.Lerp(Camera.Target.Y, (VisualPosition.Y * Globals.CELL_SIZE) - (Globals.HEIGHT / Camera.Zoom / 2), dt * (LERP_SPEED * 0.75f));
        
        base.Update(dt); // updates visual pos
        hand.Update(dt);
    
        // Update stuff
        Timer = Timer += dt < 1f ? Timer : 0f;
        if (timeSinceMove > 0f)
        {
            timeSinceMove -= dt;
            return;
        }
        

        if (Raylib.IsKeyDown(KeyboardKey.W)) Movement.Y = -1;
        if (Raylib.IsKeyDown(KeyboardKey.S)) Movement.Y = 1;
        if (Raylib.IsKeyDown(KeyboardKey.A)) Movement.X = -1;
        if (Raylib.IsKeyDown(KeyboardKey.D)) Movement.X = 1;

        if (Raylib.IsKeyDown(KeyboardKey.Minus))
        {
            Camera.Zoom -= 15f * dt;
            // auto update for better feel
            Camera.Target.X = (VisualPosition.X * Globals.CELL_SIZE) - (Globals.WIDTH / Camera.Zoom / 2);
            Camera.Target.Y = (VisualPosition.Y * Globals.CELL_SIZE) - (Globals.HEIGHT / Camera.Zoom / 2);
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Equal))
        {
            Camera.Zoom += 15f * dt;
            Camera.Target.X = (VisualPosition.X * Globals.CELL_SIZE) - (Globals.WIDTH / Camera.Zoom / 2);
            Camera.Target.Y = (VisualPosition.Y * Globals.CELL_SIZE) - (Globals.HEIGHT / Camera.Zoom / 2);
        }

        // handle collision

        if (Move())
        {
            timeSinceMove = MAX_MOVE_DELAY;
        }
        Movement.X = 0;
        Movement.Y = 0;
    }
}