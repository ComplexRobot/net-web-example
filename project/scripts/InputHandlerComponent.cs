using Godot;
using Godot.Collections;

[GlobalClass]
public partial class InputHandlerComponent : Node
{
    [Export] public Array<HandleInputStrategy> HandleInputStrategy;

    public override void _Process(double delta)
    {
        var direction = Input.GetVector("turn_left", "turn_right", "turn_down", "turn_up");
        var zoomDirection = Input.GetAxis("zoom_in", "zoom_out");
        foreach (var strategy in HandleInputStrategy)
        {
            strategy.ApplyInput(direction, zoomDirection);
        }
    }
}