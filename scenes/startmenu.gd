extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	pass


func _on_start_game_pressed():
	get_tree().change_scene_to_file("res://scenes/playspace.tscn")


func _on_quit_pressed():
	get_tree().quit()
