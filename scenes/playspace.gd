extends Node2D

var player_one: Node
var player_two: Node
const CARD = preload("res://scenes/card.tscn")

# Called when the node enters the scene tree for the first time.
func _ready():
	player_one = $PlayerOne/Deckspace
	player_two = $PlayerTwo/Deckspace
	
	for i in range(5):
		player_one.add_child(CARD.instantiate())
		player_two.add_child(CARD.instantiate())
		

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
