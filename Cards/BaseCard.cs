using Godot;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;

public enum Element
{
	NONE = 0,
	GOROGORO,
	GOMUGOMU,
	GORUGORU
};

public enum Player
{
	NONE_PLAYER=0,
	PLAYERONE,
	PLAYERTWO
}

public enum Color
{
	NONE_COLOR=0,
	RED,
	ORANGE,
	YELLOW,
	GREEN,
	BLUE,
	PURPLE
};

public partial class BaseCard : MarginContainer
{
	public Element element;
	public int level;
	public Color color;
	public int id;
	public Texture2D texture;
	public Sprite2D sprite;
	public Player player;
	

	public void Init(Element el, int level, Color clr, int id, Player player)
	{
		GD.Print("Initializing image...\n");

		// Sets Init value
		this.element = el;
		this.level = level;
		this.color = clr;
		this.id = id;
		this.player = player;

		// Imports texture image
		texture = (Texture2D)GD.Load($"res://Images/{this.element}/{this.color}{this.element}{this.level}.png");

		// Sets texture image
		sprite = GetNode<Sprite2D>("CardImg");
		sprite.Texture = texture;
	}

/*	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton clicked)
		{
			if (clicked.Pressed)
			{
				GD.Print($"CLICKED ON CARD {this.color}");
			}
		}

	}*/

	public override Variant _GetDragData(Vector2 atPosition)
	{
		GD.Print($"Sprite: {this.sprite}");
		return sprite.Texture;
	}

	public override void _Ready()
	{
	}

/*    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton clicked)
        {
            if (clicked.Pressed)
			{
                GD.Print($"CLICKED ON CARD {clicked.Position}");
            }
        }

    }*/

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
