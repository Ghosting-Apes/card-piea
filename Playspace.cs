using Godot;
using System;
using System.Collections;
using System.Drawing;

public partial class Playspace : Node2D
{
	// Called when the node enters the scene tree for the first time.

	PackedScene BaseCard = (PackedScene)ResourceLoader.Load("res://Cards/BaseCard.tscn");

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
		for (int elem = 0; elem < 3; elem++)
		{

			switch (elem)
			{
				case 0:
					// RUBBER
					el = Element.GOMUGOMU;
					break;

				case 1:
					// LIGHTNING
					el = Element.GOROGORO;
					break;

				case 2:
					// GOLD
					el = Element.GORUGORU;
					break;

				default:
					el = Element.NONE;
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
					var secondCard = (BaseCard)BaseCard.Instantiate();

					// Initializes values
					newCard.Init(el, level, clr, counter, Player.PLAYERONE);
					secondCard.Init(el, level, clr, counter, Player.PLAYERTWO);


					GD.Print($"Enum: {newCard.color}");

					// Adds cards to ArrayList
					PlayerOneCards.Add(newCard);
					PlayerTwoCards.Add(secondCard);

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
			var p1Card = (BaseCard)PlayerOneCards[i];
			p1Card.Name = $"BaseCard{i}";

			var p2Card = (BaseCard)PlayerTwoCards[i];
			p2Card.Name = $"BaseCard{i+5}";

			PlayerOneDeck.AddChild(p1Card);
			PlayerTwoDeck.AddChild(p2Card);
		}

		PlayerOneDeck.PrintTreePretty();
		PlayerTwoDeck.PrintTreePretty();

	}






	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
