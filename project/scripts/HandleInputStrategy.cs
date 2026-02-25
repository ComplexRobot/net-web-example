using Godot;

[GlobalClass]
public abstract partial class HandleInputStrategy : Node
{
    public abstract void ApplyInput(Vector2 direction, float zoomDirection);
}
