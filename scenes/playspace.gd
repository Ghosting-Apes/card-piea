extends Node2D

var player_one: Node
var player_two: Node

var P1CardHolder
var P2CardHolder
	
const CARD = preload("res://scenes/card.tscn")
var rng = RandomNumberGenerator.new()

# Information for each generated card
var image: Image
var level
var color
var type

var player_one_deck = create_deck()
var player_two_deck = create_deck()

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
	
	P1CardHolder = $PlayerOne/P1CardHolder
	P2CardHolder = $PlayerTwo/P2CardHolder
	
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
	while(player_one_deck and player_one.get_child_count() < 5):
		player_one.add_child(player_one_deck[0])
		player_one_deck.remove_at(0)
	
	while(player_two_deck and player_two.get_child_count() < 5):
		player_two.add_child(player_one_deck[0])
		player_two_deck.remove_at(0)
	
	if P1CardHolder.card and P2CardHolder.card:
		var winner = get_winner(P1CardHolder.card, P2CardHolder.card)
		print("Winner is ", winner, "!!")
		
		P1CardHolder.card = null
		P1CardHolder.texture = null
		
		P2CardHolder.card = null
		P2CardHolder.texture = null
		
func get_winner(p1: Card, p2: Card) -> int:
	match p1.card_type:
		"gomu":
			if p2.card_type == "goro":
				return 1
			elif p2.card_type == "goru":
				return 2
			if p1.level > p2.level:
				return 1
			elif p2.level > p1.level:
				return 2
		"goro":
			match p2.card_type:
				"goru":
					return 1
				"gomu":
					return 2
			if p1.level > p2.level:
				return 1
			elif p2.level > p1.level:
				return 2
		"goru":
			match p2.card_type:
				"gomu":
					return 1
				"goro":
					return 2
			if p1.level > p2.level:
				return 1
			elif p2.level > p1.level:
				return 2
	return 0
			
