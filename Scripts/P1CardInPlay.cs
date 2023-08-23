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
        return data.AsGodotObject().GetType().GetField("player").GetValue(data.AsGodotObject()) is Player.PLAYERONE;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        // Gets Card being dragged
        var card = (BaseCard)data;
        GD.Print(card.Name);

        // Sets the texture of the Card in Play
        this.Texture = (Texture2D)data.AsGodotObject().GetType().GetField("texture").GetValue(data.AsGodotObject());

        // Deletes Card being played from Deck
        var child = GetNode<BaseCard>($"/root/Playspace/PlayerOneDeck/DeckSpace/{card.Name}");
        var parentTest = GetNode<P1DeckSpace>("/root/Playspace/PlayerOneDeck/DeckSpace");
        parentTest.RemoveChild(child);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
