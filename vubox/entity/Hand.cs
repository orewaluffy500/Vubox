using vubox.blocks;
using vubox.engine;
using vubox.engine.blockconfig;
using Raylib_cs;

namespace vubox.entity;

public class Hand(Player player) : Entity
{
    internal Player Player = player;
    internal int SelectedIndex = 0;
    internal string Selected = "";
    internal BlockConfig? SelectedConfig;

    public string SelectedBlockName { get => SelectedConfig?.DisplayName ?? "null"; }

    public override void Load()
    {
        var keys = BlockLoader.Configs.Keys.ToArray();

        Selected = keys[SelectedIndex];
        SelectedConfig = BlockLoader.GetConfig(Selected);
    }
    public override void Draw()
    {
        Raylib.DrawRectangle(
            (int)(VisualPosition.X * Globals.CELL_SIZE) + 1,
            (int)(VisualPosition.Y * Globals.CELL_SIZE) + 1,
            Globals.CELL_SIZE - 2,
            Globals.CELL_SIZE - 2,
            new(90, 255, 90, 125)
        );
    }

    public override void Update(float dt)
    {
        base.Update(dt);

        var (x, y) = (Raylib.GetMouseX(), Raylib.GetMouseY());
        var v = Raylib.GetScreenToWorld2D(new(x, y), Player.Camera);
        var (ix, iy) = (MathF.Round(v.X / Globals.CELL_SIZE) * Globals.CELL_SIZE, MathF.Round(v.Y / Globals.CELL_SIZE) * Globals.CELL_SIZE);
        X = (int)(ix / Globals.CELL_SIZE);
        Y = (int)(iy / Globals.CELL_SIZE);

        var keys = BlockLoader.Configs.Keys.ToArray();

        if (Raylib.IsKeyPressed(KeyboardKey.Tab))
        {
            SelectedIndex = ++SelectedIndex < keys.Length ? SelectedIndex : 0;
            Selected = keys[SelectedIndex];
            SelectedConfig = BlockLoader.GetConfig(Selected);
        }

        else if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            Player.Engine.World.DestroyAsync(X, Y);
        }

        else if (Raylib.IsMouseButtonDown(MouseButton.Right))
        {
            Player.Engine.World.PlaceAsync(Selected, X, Y);
        }

        else if (Raylib.IsKeyPressed(KeyboardKey.F))
        {
            if (Player.Engine.World.GetBlock(X, Y) is Block b) b.Interact();
        }
    }
}