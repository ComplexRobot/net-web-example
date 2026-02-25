using Godot;
using System;

[GlobalClass]
public partial class Main : Node3D
{
    [Export]
    public PackedScene MenuScene;
    public override void _Ready()
    {
        
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("menu"))
        {
            GetTree().ChangeSceneToPacked(MenuScene);
        }
    }

    public void Spawn(Node node)
    {
        var spawnPosition = GetNode<Node3D>("SpawnPosition");
        foreach (var child in spawnPosition.GetChildren())
        {
            child.QueueFree();
        }
        spawnPosition.AddChild(node);
    }
}
