using Godot;
using System;

public partial class P1CardInPlay : Godot.TextureRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        var test = data.AsGodotObject().GetType().GetField("player").GetValue(data.AsGodotObject());


        //GD.Print($"From {test}");
        return data.AsGodotObject().GetType().GetField("player").GetValue(data.AsGodotObject()) is Player.PLAYERONE;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        this.Texture = (Texture2D)data.AsGodotObject().GetType().GetField("texture").GetValue(data.AsGodotObject());
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
