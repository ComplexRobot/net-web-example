using Godot;

[GlobalClass]
public partial class MoveHandleInputStrategy : HandleInputStrategy
{
    [Export] public CharacterBody3D CharacterBody;

    public override void ApplyInput(Vector2 direction, float zoomDirection)
    {
        CharacterBody.Velocity = new Vector3(direction.X, 0, direction.Y);
        CharacterBody.MoveAndSlide();
    }
}