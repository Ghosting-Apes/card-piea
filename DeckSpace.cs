using Godot;
using System;

public partial class DeckSpace : HBoxContainer
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
		return x.texture;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton clicked)
        {
            if (clicked.Pressed)
            {
                GD.Print($"CLICKED ON CARD {clicked.Position}");
                GD.Print($"X: {clicked.Position.X}");
                GD.Print($"Y: {clicked.Position.Y}");
                if (clicked.Position.Y < 650 && clicked.Position.Y > 450)
                {
                    int cardPos = (int)clicked.Position.X / 120;
                    

                    switch (cardPos)
                    {
                        case 0:
                            GD.Print("FIRST CARD");
                            x = GetNode<BaseCard>("BaseCard");
                            GD.Print($"Color: {x.color}");
                            break;
                        case 1:
                            GD.Print("SECOND CARD");
                            x = GetNode<BaseCard>("@MarginContainer@2");
                            GD.Print($"Color: {x.color}");
                            break;
                        case 2:
                            GD.Print("THIRD CARD");
                            x = GetNode<BaseCard>("@MarginContainer@4");
                            GD.Print($"Color: {x.color}");
                            break;
                        case 3:
                            GD.Print("FOURTH CARD");
                            x = GetNode<BaseCard>("@MarginContainer@6");
                            GD.Print($"Color: {x.color}");
                            break;
                        case 4:
                            GD.Print("FIFTH CARD");
                            x = GetNode<BaseCard>("@MarginContainer@8");
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
