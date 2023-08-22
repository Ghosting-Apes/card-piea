using Godot;
using System;

public partial class TextureRect : Godot.TextureRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return (Texture2D)data is Texture2D;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        this.Texture = (Texture2D)data;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
