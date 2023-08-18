using Godot;
using System;

public partial class Playspace : Node2D
{
	// Called when the node enters the scene tree for the first time.

	PackedScene BaseCard = (PackedScene)ResourceLoader.Load("res://Cards/BaseCard.tscn");

	public override void _Ready()
	{
		GD.Print("Rendering Playspace...");
	}

    public override void _UnhandledInput(InputEvent @event)
    {
		if(@event is InputEventMouseButton clicked)
		{
			if(clicked.Pressed)
			{
				GD.Print("CLICKED ON SCREEN");
                var new_card = (MarginContainer)BaseCard.Instantiate();
				new_card.Name = "CARD";
				new_card.Position = GetGlobalMousePosition();

                var deck = GetNode<Node>("Deck");
                deck.AddChild(new_card);
/*                base._UnhandledInput(@event);*/
            }
		}
		
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
