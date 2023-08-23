using Godot;
using System;
using static Godot.TextureRect;

public partial class P1DeckSpace : HBoxContainer
{
    public BaseCard chosen;

    public Sprite2D sprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override Variant _GetDragData(Vector2 atPosition)
    {
		GD.Print(atPosition);
        GD.Print($"DRAGGING... {chosen.color}\n");


        // Drag preview
        var preview_text = new TextureRect();
        preview_text.Texture = chosen.texture;
        preview_text.ExpandMode = (ExpandModeEnum)1;
        preview_text.Size = new Vector2(70, 100);

        var preview = new Control();
        preview.AddChild(preview_text);

        SetDragPreview(preview);
        return chosen;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton clicked)
        {
            if (clicked.Pressed)
            {
                if (clicked.Position.Y < 650 && clicked.Position.Y > 450)
                {
                    if (clicked.Position.X >= 0 && clicked.Position.X <= 600)
                    {
                        GD.Print("P1DeckSpace.cs\n");
                        GD.Print($"CLICKED ON CARD {clicked.Position}");

                        int cardPos = (int)clicked.Position.X / (600 / GetChildren().Count);
                        chosen = (BaseCard)GetChildren()[cardPos];
                        GD.Print($"Chosen: {chosen.Name}");
                    }
                }
            }
        }

    }


}
