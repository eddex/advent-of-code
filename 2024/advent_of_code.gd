extends Control

func _ready() -> void:
	var day1 = Day1.new()
	print(day1.solve_part1("res://input/test-day-01.txt"))
	print(day1.solve_part1("res://input/input-day-01.txt"))
	print(day1.solve_part2("res://input/test-day-01.txt"))
	print(day1.solve_part2("res://input/input-day-01.txt"))
