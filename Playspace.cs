using Godot;
using System;
using System.Collections;
using System.Drawing;

public partial class Playspace : Node2D
{
	// Called when the node enters the scene tree for the first time.

	PackedScene BaseCard = (PackedScene)ResourceLoader.Load("res://Cards/BaseCard.tscn");
	ArrayList player1Deck = new ArrayList();
	ArrayList player2Deck = new ArrayList();

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
		var playerOneDeck = GetNode<Node>("Player1_Deck");
		var playerTwoDeck = GetNode<Node>("Player2_Deck");
		
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

                    // Initializes values
                    newCard.Init(el, level, clr, counter);


					GD.Print($"Enum: {newCard.color}");
					
					// Sets position and adds to deck
					player1Deck.Add(newCard);
                    counter++;
                }

			}

        }

		Random rnd = new Random();
		rnd.Next(0, player1Deck.Count);

		Shuffle<BaseCard>(rnd, player1Deck);

		for(int i = 0; i < player1Deck.Count; i++)
		{
            int x = (100 * i) + 75;
            int y = 500;
			var hold = (BaseCard)player1Deck[i];
			hold.Position = new Vector2(x, y);
            playerOneDeck.AddChild(hold);
        }

		

		// Player 1 Deck
/*		for(int i = 0; i < 5; i++)
		{
			var newCard = (BaseCard)BaseCard.Instantiate();
			newCard.Name = $"Card {i} for Player 1";
			
			int x = (100 * i) + 75;
			int y = 500;
			newCard.Position = new Vector2(x, y);
			playerOneDeck.AddChild(newCard);
		}*/


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
