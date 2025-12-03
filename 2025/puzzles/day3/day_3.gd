extends Control

func _ready() -> void:
	var result_part_1 := solve_part_1("res://puzzles/day3/test.txt")
	print("Test:     ", result_part_1, "✅" if result_part_1 == 357 else "❌")
	print("Solution: ", solve_part_1("res://puzzles/day3/input.txt"))
#
	var result_part_2 := solve_part_2("res://puzzles/day3/test.txt")
	print("Test:     ", result_part_2, "✅" if result_part_2 == 3121910778619 else "❌")
	print("Solution: ", solve_part_2("res://puzzles/day3/input.txt"))

func solve_part_1(path: String) -> int:
	var lines: Array[String] = read_input(path)
	var sum := 0
	for line in lines:
		var numbers : Array[int] = string_to_int_array(line)
		var a : int = numbers.max()
		var b := 0
		var idx_a : int = line.find(str(a))
		if idx_a == len(line) -1:
			numbers.remove_at(idx_a)
			b = a
			a = numbers.max()
		else:
			var remaining_str : String = line.substr(idx_a + 1)
			var remaining_num : Array[int] = string_to_int_array(remaining_str)
			b = remaining_num.max()

		var joltage := int("%s%s" % [a, b])
		sum += joltage
	return sum

func solve_part_2(path: String) -> int:
	var lines: Array[String] = read_input(path)
	var sum := 0
	for line in lines:
		var start_idx := 0
		var numbers := string_to_int_array(line)
		var joltage : Array[int] = []
		for i in range(12):
			var end_idx := len(line) - 12 + i
			var search_area := numbers.slice(start_idx, end_idx + 1)
			var max_num : int = search_area.max()
			var max_idx := search_area.find(max_num)
			start_idx += max_idx + 1
			joltage.append(max_num)
		sum += int(str(joltage))
	return sum

func string_to_int_array(s: String) -> Array[int]:
	var numbers : Array[int] = []
	for c in s:
		numbers.append(int(c))
	return numbers

func read_input(path: String) -> Array[String]:
	var file = FileAccess.open(path, FileAccess.READ)
	var lines : Array[String] = []
	while not file.eof_reached():
		var line: String = file.get_line()
		if line != "":
			lines.append(line)
	return lines
