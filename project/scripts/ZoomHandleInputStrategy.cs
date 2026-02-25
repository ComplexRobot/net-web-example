using Godot;

[GlobalClass]
public partial class ZoomHandleInputStrategy : HandleInputStrategy
{
    [Export] public CharacterBody3D CharacterBody;

    public override void ApplyInput(Vector2 direction, float zoomDirection)
    {
        if (zoomDirection == 0)
        {
            return;
        }
        GetTree().CreateTween()
            .TweenProperty(CharacterBody, "scale", CharacterBody.Scale + zoomDirection * Vector3.One * .2f, 3f)
            .SetEase(Tween.EaseType.InOut);
    }
}