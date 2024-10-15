extends MarginContainer
var image: Image


func build(lvl: int, clr: String, type: String):
	var path = "res://images/"+type+"/"+clr+type+type+str(lvl)+".png"
	image = Image.load_from_file(path)
	$Sprite2D.texture = ImageTexture.create_from_image(image)

# Called when the node enters the scene tree for the first time.
func _ready():
	pass
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
