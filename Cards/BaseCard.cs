using Godot;
using System;

public partial class BaseCard : MarginContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Random random = new Random();
		var x = random.Next(0, 2);

		Texture2D texture;
        if (x == 0)
		{
            texture = (Texture2D)GD.Load("res://Images/redgomugomu10.png");
        }
		else
		{
            texture = (Texture2D)GD.Load("res://Images/purplegomugomu10.png");
        }
		
		var sprite = GetNode<Sprite2D>("CardImg");
        sprite.Texture = texture;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
