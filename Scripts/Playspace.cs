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
            PlayerOneDeck.AddChild((BaseCard)PlayerOneCards[i]);
            PlayerOneCards.RemoveAt(i);

            PlayerTwoDeck.AddChild((BaseCard)PlayerTwoCards[i]);
            PlayerTwoCards.RemoveAt(i);
		}

		PlayerOneDeck.PrintTreePretty();
		PlayerTwoDeck.PrintTreePretty();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Checks if more cards need to be added to deck
        var PlayerOneDeck = GetNode<HBoxContainer>("PlayerOneDeck/DeckSpace");
		var PlayerTwoDeck = GetNode<HBoxContainer>("PlayerTwoDeck/DeckSpace");
		if (PlayerOneCards.Count > 0)
        {
            if (PlayerOneDeck.GetChildCount() < 5)
            {
                PlayerOneDeck.AddChild((BaseCard)PlayerOneCards[0]);
                PlayerOneCards.RemoveAt(0);
            }

        }

        if (PlayerTwoCards.Count > 0)
        {
            if (PlayerTwoDeck.GetChildCount() < 5)
            {
                PlayerTwoDeck.AddChild((BaseCard)PlayerTwoCards[0]);
                PlayerTwoCards.RemoveAt(0);
            }

        }

		// Game Logic
		var p1Chosen = GetNode<CenterContainer>("Chosen1/Panel/CenterContainer");
		var p2Chosen = GetNode<CenterContainer>("Chosen2/Panel/CenterContainer");

		var p1WinBox = GetNode<HBoxContainer>("PlayerOneWin");

		CenterContainer winLoc = null;

		if(p1Chosen.GetChildCount() > 0 && p2Chosen.GetChildCount() > 0)
		{
			// Selected cards
			var selected1 = (BaseCard)p1Chosen.GetChildren()[0];
            var selected2 = (BaseCard)p2Chosen.GetChildren()[0];

            GD.Print($"Selected 1: {selected1.Name}");
            GD.Print($"Selected 2: {selected2.Name}");


            if (selected1.element == Element.GOMUGOMU)
			{
				if(selected2.element == Element.GOROGORO)
				{
					GD.Print("PLAYER 1 WINS");
					winLoc = (CenterContainer)((VBoxContainer)p1WinBox.GetChildren()[0]).GetChildren()[0];
				}
				else if(selected2.element == Element.GORUGORU)
				{
					GD.Print("PLAYER 2 WINS");

				}
				else
				{
					GD.Print("TIE");
				}
			}
			else if(selected1.element == Element.GORUGORU)
			{
				if(selected2.element == Element.GOROGORO)
				{
                    GD.Print("PLAYER 2 WINS");
                }
				else if(selected2.element == Element.GOMUGOMU)
				{
					GD.Print("PLAYER 1 WINS");
                    winLoc = (CenterContainer)((VBoxContainer)p1WinBox.GetChildren()[2]).GetChildren()[0];
                }
				else
				{
					GD.Print("TIE");
				}
			}
			else
			{
				if(selected2.element == Element.GORUGORU)
				{
                    GD.Print("PLAYER 1 WINS");
                    winLoc = (CenterContainer)((VBoxContainer)p1WinBox.GetChildren()[1]).GetChildren()[0];

                }
				else if(selected2.element == Element.GOMUGOMU)
				{
                    GD.Print("PLAYER 2 WINS");

                }
				else
				{
					GD.Print("TIE");
				}
            }

			p1Chosen.RemoveChild(selected1);
			p2Chosen.RemoveChild(selected2);
			winLoc.AddChild(selected1);
		}
    }
}
