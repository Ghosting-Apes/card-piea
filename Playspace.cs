using Godot;
using System;

public partial class Playspace : Node2D
{
	// Called when the node enters the scene tree for the first time.

	PackedScene BaseCard = (PackedScene)ResourceLoader.Load("res://Cards/BaseCard.tscn");

	public override void _Ready()
	{
		GD.Print("Rendering Playspace...");
		var playerOneDeck = GetNode<Node>("Player1_Deck");
		var playerTwoDeck = GetNode<Node>("Player2_Deck");

		// Player 1 Deck
		for(int i = 0; i < 5; i++)
		{
			var newCard = (MarginContainer)BaseCard.Instantiate();
			newCard.Name = $"Card {i} for Player 1";
			int x = (100 * i) + 75;
			int y = 500;
			newCard.Position = new Vector2(x, y);
			playerOneDeck.AddChild(newCard);
		}


		// Player 2 Deck
		for (int i = 0; i < 5; i++)
		{
			var newCard = (MarginContainer)BaseCard.Instantiate();
			newCard.Name = $"Card {i} for Player 2";
			int x = (100 * i) + 650;
			int y = 100;
			newCard.Position = new Vector2(x, y);
			playerTwoDeck.AddChild(newCard);
		}
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton clicked)
		{
			if (clicked.Pressed)
			{
				GD.Print($"CLICKED ON SCREEN {GetGlobalMousePosition()}");
				/*				var new_card = (MarginContainer)BaseCard.Instantiate();
								new_card.Name = "CARD";
								new_card.Position = GetGlobalMousePosition();

								var deck = GetNode<Node>("Deck");
								deck.AddChild(new_card);
								base._UnhandledInput(@event);*/
			}
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
