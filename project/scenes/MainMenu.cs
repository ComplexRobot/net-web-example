using Godot;
using System;

public partial class MainMenu : Control
{
    [Export] public PackedScene Cube;
    [Export] public PackedScene Sphere;
    [Export] public PackedScene Torus;

    private PackedScene _mainScene;

    public override void _Ready()
    {
        _mainScene = ResourceLoader.Load<PackedScene>("res://main.tscn");
        GetNode<Button>("VBoxContainer/Cube").Pressed += () => ChangeToMainAndSpawn(Cube.Instantiate());
        GetNode<Button>("VBoxContainer/Sphere").Pressed += () => ChangeToMainAndSpawn(Sphere.Instantiate());
        GetNode<Button>("VBoxContainer/Torus").Pressed += () => ChangeToMainAndSpawn(Torus.Instantiate());
    }

    private void ChangeToMainAndSpawn(Node node)
    {
        var callable = Callable.From<Node>((sender) =>
        {
            if (sender is Main mainScene)
            {
                mainScene.Spawn(node);
            }
        });
        GetTree().Root.Connect(Node.SignalName.ChildEnteredTree, callable, (uint)ConnectFlags.OneShot);
        GetTree().ChangeSceneToPacked(_mainScene);
    }
}