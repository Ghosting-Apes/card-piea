using Godot;
using System;
using static Godot.TextureRect;

public partial class P1DeckSpace : HBoxContainer
{
    public BaseCard x;

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
        GD.Print($"DRAGGING... {x.color}\n");

        // Drag preview
        var preview_text = new TextureRect();
        preview_text.Texture = x.texture;
        preview_text.ExpandMode = (ExpandModeEnum)1;
        preview_text.Size = new Vector2(70, 100);

        var preview = new Control();
        preview.AddChild(preview_text);

        SetDragPreview(preview);
        return x;
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
                        GD.Print($"X: {clicked.Position.X}");
                        GD.Print($"Y: {clicked.Position.Y}\n");

                        int cardPos = (int)clicked.Position.X / 120;

                        switch (cardPos)
                        {
                            case 0:
                                GD.Print("FIRST CARD P1");
                                x = GetNode<BaseCard>("BaseCard0");
                                GD.Print($"Color: {x.color}");
                                break;
                            case 1:
                                GD.Print("SECOND CARD P1");
                                x = GetNode<BaseCard>("BaseCard1");
                                GD.Print($"Color: {x.color}");
                                break;
                            case 2:
                                GD.Print("THIRD CARD P1");
                                x = GetNode<BaseCard>("BaseCard2");
                                GD.Print($"Color: {x.color}");
                                break;
                            case 3:
                                GD.Print("FOURTH CARD P1");
                                x = GetNode<BaseCard>("BaseCard3");
                                GD.Print($"Color: {x.color}");
                                break;
                            case 4:
                                GD.Print("FIFTH CARD P1");
                                x = GetNode<BaseCard>("BaseCard4");
                                GD.Print($"Color: {x.color}");
                                break;
                            default:
                                GD.Print("NONE");
                                break;
                        }
                    }
                }
            }
        }

    }


}
