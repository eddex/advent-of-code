extends Control

func _ready() -> void:
	var result_part_1 := solve_part_1("res://puzzles/day2/test.txt")
	print("Test:     ", result_part_1, "✅" if result_part_1 == 1227775554 else "❌")
	print("Solution: ", solve_part_1("res://puzzles/day2/input.txt"))
#
	var result_part_2 := solve_part_2("res://puzzles/day2/test.txt")
	print("Test:     ", result_part_2, "✅" if result_part_2 == 4174379265 else "❌")
	print("Solution: ", solve_part_2("res://puzzles/day2/input.txt"))

func solve_part_1(path: String) -> int:
	var ranges: Array[Dictionary] = read_input(path)
	var sum : int = 0
	for range_vec: Dictionary in ranges:
		var i : int = range_vec["start"]
		while i <= int(range_vec["end"]):
			var i_str := str(i)
			if len(i_str) % 2 == 0:
				if i_str == i_str.left(len(i_str) / 2).repeat(2):
					sum += i
			i += 1
	return sum

func solve_part_2(path: String) -> int:
	var ranges: Array[Dictionary] = read_input(path)
	var sum : int = 0
	for range_vec: Dictionary in ranges:
		var i : int = range_vec["start"]
		while i <= int(range_vec["end"]):
			if is_invalid_id(str(i)):
				sum += i
			i += 1
	return sum

func is_invalid_id(id: String) -> bool:
	for i in range(1, len(id) / 2 + 1):
		if id == id.substr(0, i).repeat(len(id) / i):
			return true
	return false

func read_input(path: String) -> Array[Dictionary]:
	var file = FileAccess.open(path, FileAccess.READ)
	var raw_input := file.get_line()
	var range_strings := raw_input.split(",")
	var ranges : Array[Dictionary] = []
	for range_str in range_strings:
		var min_max := range_str.split("-")
		ranges.append({ "start" = int(min_max[0]), "end" = int(min_max[1])})
	return ranges
