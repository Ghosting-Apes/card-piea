using Godot;
using System;
using System.Collections;
using System.Drawing;

public partial class Playspace : Node2D
{
	// Called when the node enters the scene tree for the first time.

	PackedScene BaseCard = (PackedScene)ResourceLoader.Load("res://Cards/BaseCard.tscn");
/*	PackedScene BaseDeck = (PackedScene)ResourceLoader.Load("res://Deck/Deck.tscn");*/

	ArrayList PlayerOneCards = new ArrayList();
	ArrayList PlayerTwoCards = new ArrayList();

	public static void Shuffle<T>(Random rng, ArrayList array)
	{
		int n = array.Count;
		while (n > 1)
		{
			int k = rng.Next(n--);
			T temp = (T)array[n];
			array[n] = array[k];
			array[k] = temp;
		}
	}



	public override void _Ready()
	{
		GD.Print("Rendering Playspace...");
		var PlayerOneDeck = GetNode<HBoxContainer>("PlayerOneDeck/DeckSpace");
		var PlayerTwoDeck = GetNode<HBoxContainer>("PlayerTwoDeck/DeckSpace");


		// Place-holder values for card
		int counter = 0;
		Element el = Element.NONE;
		int level = 0;
		Color clr = Color.NONE_COLOR;

		// Sets values for card
		for (int elem = 0; elem < 1; elem++)
		{

			switch (elem)
			{
				case 0:
					el = Element.GOMUGOMU;
					break;
			}
			for (int lvl = 0; lvl < 1; lvl++)
			{
				switch (lvl)
				{
					case 0:
						level = 10;
						break;
				}
				for (int color = 0; color < 6; color++)
				{


					switch (color)
					{
						case 0:
							clr = Color.RED;
							break;
						case 1:
							clr = Color.ORANGE;
							break;
						case 2:
							clr = Color.YELLOW;
							break;
						case 3:
							clr = Color.GREEN;
							break;
						case 4:
							clr = Color.BLUE;
							break;
						case 5:
							clr = Color.PURPLE;
							break;
					}
					// Creates BaseCard node
					var newCard = (BaseCard)BaseCard.Instantiate();
/*					var newPlayerTwoCard = (BaseCard)BaseCard.Instantiate();*/

					// Initializes values
					newCard.Init(el, level, clr, counter);
/*					newPlayerTwoCard.Init(el, level, clr, counter);*/



					GD.Print($"Enum: {newCard.color}");

					// Adds cards to ArrayList
					PlayerOneCards.Add(newCard);
					PlayerTwoCards.Add(newCard.Duplicate());

					// ID
					counter++;
				}

			}

		}


		// Randomizes Player Card options
		Random rnd = new Random();
		rnd.Next(0, PlayerOneCards.Count);
		Shuffle<BaseCard>(rnd, PlayerOneCards);
		Shuffle<BaseCard>(rnd, PlayerTwoCards);


		// Appends cards to deck
		for (int i = 0; i < 5; i++)
		{
			PlayerOneDeck.AddChild((BaseCard)PlayerOneCards[i]);
			PlayerTwoDeck.AddChild((BaseCard)PlayerTwoCards[i]);
		}

		PlayerOneDeck.PrintTreePretty();


		// Player 2 Deck
		/*		for (int i = 0; i < 5; i++)
				{
					var newCard = (MarginContainer)BaseCard.Instantiate();
					newCard.Name = $"Card {i} for Player 2";
					int x = (100 * i) + 650;
					int y = 100;
					newCard.Position = new Vector2(x, y);
					playerTwoDeck.AddChild(newCard);
				}*/
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
