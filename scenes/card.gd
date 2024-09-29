extends MarginContainer

var rng = RandomNumberGenerator.new()



# Called when the node enters the scene tree for the first time.
func _ready():
	var texture: ImageTexture
	var rand = rng.randi_range(0, 5)
	
	match rand:
		0:
			var image = Image.load_from_file("res://images/gomu/bluegomugomu1.png")
			$Sprite2D.texture = ImageTexture.create_from_image(image)
		1:
			var image = Image.load_from_file("res://images/gomu/redgomugomu1.png")
			$Sprite2D.texture = ImageTexture.create_from_image(image)
		2:
			var image = Image.load_from_file("res://images/gomu/yellowgomugomu1.png")
			$Sprite2D.texture = ImageTexture.create_from_image(image)
		3:
			var image = Image.load_from_file("res://images/gomu/purplegomugomu1.png")
			$Sprite2D.texture = ImageTexture.create_from_image(image)
		4:
			var image = Image.load_from_file("res://images/gomu/orangegomugomu1.png")
			$Sprite2D.texture = ImageTexture.create_from_image(image)
		5:
			var image = Image.load_from_file("res://images/gomu/greengomugomu1.png")
			$Sprite2D.texture = ImageTexture.create_from_image(image)
		_:
			print("WHOOPS: ",rand)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
