using Godot;
using System;

public partial class board : Node2D
{
	int x = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello!!");
		Console.WriteLine("HELLO WITH WRITELINE");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
