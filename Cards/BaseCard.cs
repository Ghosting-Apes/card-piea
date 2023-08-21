using Godot;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;

public enum Element
{
    NONE = 0,
    LIGHTNING,
	GOMUGOMU,
	GOLD
};

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

    public void Init(Element el, int level, Color clr, int id)
    {
		GD.Print("Initializing image...\n");

		// Sets Init value
		this.element = el;
		this.level = level;
		this.color = clr;
		this.id = id;

		// Imports texture image
		texture = (Texture2D)GD.Load($"res://Images/{this.color}{this.element}10.png");

		// Sets texture image
		var sprite = GetNode<Sprite2D>("CardImg");
		sprite.Texture = texture;
    }

    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
