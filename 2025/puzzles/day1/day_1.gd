extends Control

func _ready() -> void:
	var result_part_1 := solve_part_1("res://puzzles/day1/test.txt")
	print("Test:     ", result_part_1, "✅" if result_part_1 == 3 else "❌")
	print("Solution: ", solve_part_1("res://puzzles/day1/input.txt"))

	var result_part_2 := solve_part_2("res://puzzles/day1/test.txt")
	print("Test:     ", result_part_2, "✅" if result_part_2 == 6 else "❌")
	print("Solution: ", solve_part_2("res://puzzles/day1/input.txt"))



func solve_part_1(path: String) -> int:
	var lines = read_input(path)
	var current_position := 50
	var result := 0
	for line in lines:
		var shift_by := int(line.replace("L", "-").replace("R", ""))
		current_position = (current_position + shift_by) % 100
		if current_position == 0:
			result += 1
	return result

func solve_part_2(path: String) -> int:
	var lines = read_input(path)
	var pos := 50
	var hits := 0
	var direction := "R"
	for line: String in lines:
		var letter := line.left(1)
		var num := int(line.erase(0, 1))

		if letter != direction:
			pos = (100 - pos) % 100
			direction = letter

		pos += num
		hits += pos / 100
		pos = pos % 100

	return hits

func read_input(path: String) -> Array[String]:
	var file = FileAccess.open(path, FileAccess.READ)
	var lines : Array[String] = []
	while not file.eof_reached():
		lines.append(file.get_line())
	return lines
