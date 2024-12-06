extends Control

func _ready() -> void:
	#day1()
	day2()


func day1():
	var day1 = Day1.new()
	print(day1.solve_part1("res://input/test-day-01.txt"))
	print(day1.solve_part1("res://input/input-day-01.txt"))
	print(day1.solve_part2("res://input/test-day-01.txt"))
	print(day1.solve_part2("res://input/input-day-01.txt"))

func day2():
	var day2 = Day2.new()
	print(day2.solve_part1("res://input/test-day-02.txt"))
	print(day2.solve_part1("res://input/input-day-02.txt"))
