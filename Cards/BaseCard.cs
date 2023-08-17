using Godot;
using System;

public partial class BaseCard : MarginContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        var texture = (Texture2D)GD.Load("res://Images/redgomugomu10.png");
        var sprite = GetNode<Sprite2D>("CardImg");
        sprite.Texture = texture;

        GD.Print("WORKS WITH NEW CLASS");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
