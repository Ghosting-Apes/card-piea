using Godot;
using System;

public partial class Deck : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Rendering Deck background...");
/*		var texture = (Texture2D)GD.Load("res://Images/black_backgnd.png");

		var sprite = GetNode<Sprite2D>("DeckImg");
		sprite.Texture = texture;*/
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
