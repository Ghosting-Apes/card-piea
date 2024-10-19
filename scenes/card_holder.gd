extends TextureRect

var card: Card

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _get_drag_data(at_position):
	var preview_texture = TextureRect.new()
	
	preview_texture.texture = texture
	preview_texture.expand_mode = 1
	preview_texture.size = Vector2(30, 30)
	
	var preview = Control.new()
	preview.add_child(preview_texture)
	
	set_drag_preview(preview)
	
	return texture

func _can_drop_data(_pos, data):
	return data.get_parent().get_parent() == get_parent()

func _drop_data(_pos, data):
	card = data as Card
	print("card being dropped is ", card.tag)
	var card_parent = card.get_parent()
	print("the card's parent is ", card_parent)
	card_parent.remove_child(card)
	texture = data.texture
