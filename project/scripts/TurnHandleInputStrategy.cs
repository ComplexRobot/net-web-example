using Godot;

[GlobalClass]
public partial class TurnHandleInputStrategy : HandleInputStrategy
{
    [Export] public CharacterBody3D CharacterBody;
    [Export] public float TurnSpeed;

    public override void ApplyInput(Vector2 direction, float zoomDirection)
    {
        CharacterBody.Rotation += new Vector3(direction.Y, 0, direction.X) * TurnSpeed * (float)GetProcessDeltaTime();
    }
}