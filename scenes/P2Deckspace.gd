extends HBoxContainer

var chosen: Card

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _input(event):
	if event is InputEventMouseButton:
		print("Mouse clicked at ", event.position)
		if event.position.x <= 1270 and event.position.x >= 720:
			if event.position.y >= 0 and event.position.y <= 200:
				print("Mouse clicked on PlayerTwo at  ", event.position)
				
				var selected_Card = event.position.x / ((540 + 50) / get_child_count() ) as int - 6
				print("Selected_card: ", selected_Card)
				chosen = get_children()[selected_Card] as Card
				print("Chosen: ", chosen.tag)
				
func _get_drag_data(at_position):
	var preview_texture = TextureRect.new()
	
	preview_texture.texture = chosen.texture
	preview_texture.expand_mode = 1
	preview_texture.size = Vector2(30, 30)
	
	var preview = Control.new()
	preview.add_child(preview_texture)
	
	set_drag_preview(preview)
		
	return chosen

