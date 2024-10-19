extends MarginContainer
class_name Card

var image: Image
var texture: Texture2D

# Data used to build card
var tag: String
var level: int
var color: String
var card_type: String


func build(lvl: int, clr: String, type: String):
	# Sets global card values
	level = lvl
	color = clr
	card_type = type
	tag = type+"/"+clr+type+type+str(lvl)
	
	# Adds card image from res://images/ dir
	var path = "res://images/"+tag+".png"
	image = Image.load_from_file(path)
	texture = ImageTexture.create_from_image(image)
	$Sprite2D.texture = texture

# Called when the node enters the scene tree for the first time.
func _ready():
	pass
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

