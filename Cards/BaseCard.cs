using Godot;
using System;

public partial class BaseCard : MarginContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Random random = new Random();
		var x = random.Next(0, 6);

		Texture2D texture;
		
		
		switch(x) 
		{
			case 0: texture = (Texture2D)GD.Load("res://Images/redgomugomu10.png");
			break;
			
			case 1: texture = (Texture2D)GD.Load("res://Images/orangegomugomu10.png");
			break;
			
			case 2: texture = (Texture2D)GD.Load("res://Images/yellowgomugomu10.png");
			break;
			
			case 3: texture = (Texture2D)GD.Load("res://Images/greengomugomu10.png");
			break;
			
			case 4: texture = (Texture2D)GD.Load("res://Images/bluegomugomu10.png");
			break;
			
			case 5: texture = (Texture2D)GD.Load("res://Images/purplegomugomu10.png");
			break;
			
			default: texture = (Texture2D)GD.Load("res://Images/blankcard.png");
			break;
		}
		
		/*
		if (x == 0)
		{
			texture = (Texture2D)GD.Load("res://Images/redgomugomu10.png");
		}
		else
		{
			texture = (Texture2D)GD.Load("res://Images/purplegomugomu10.png");
		}
		*/
		
		var sprite = GetNode<Sprite2D>("CardImg");
		sprite.Texture = texture;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
