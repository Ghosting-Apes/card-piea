extends Node2D

var player_one: Node
var player_two: Node
	
const CARD = preload("res://scenes/card.tscn")

var rng = RandomNumberGenerator.new()

var image: Image
var level
var color
var type

func create_deck():
	var deck = []
	for lvl in range(10):
		for clr in range(6):
			match clr:
				0:
					color = "blue"
				1:
					color = "red"
				2:
					color = "green"
				3:
					color = "purple"
				4:
					color = "orange"
				5:
					color = "yellow"
			for t in range(3):
				match t:
					0:
						type = "gomu"
					1:
						type = "goro"
					2:
						type = "goru"
				var card = CARD.instantiate();
				card.build(lvl+1, color, type)
				deck.append(card)
	return deck
				

# Called when the node enters the scene tree for the first time.
func _ready():
	player_one = $PlayerOne/Deckspace
	player_two = $PlayerTwo/Deckspace
	
	var player_one_deck = create_deck()
	var player_two_deck = create_deck()
	
	player_one_deck.shuffle()
	player_two_deck.shuffle()
	
	for i in range(5):
		player_one.add_child(player_one_deck[i])
		player_one_deck.remove_at(i)
		player_two.add_child(player_two_deck[i])
		player_two_deck.remove_at(i)
		
	print("Number of cards in p1 deck: ", len(player_one_deck))
	print("Number of cards in p2 deck: ", len(player_two_deck))

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
