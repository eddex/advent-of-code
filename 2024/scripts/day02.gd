extends Node
class_name Day2


func solve_part1(path: String) -> int:
	var lines: Array = read_input(path)
	var safeLines = 0
	for line: Array in lines:
		var copy: Array = line.duplicate()
		copy.sort()
		if copy != line:
			copy.reverse()
			if copy != line:
				continue # line is not sorted in asc or desc order
		var previous = null
		var isSafe = true
		for num: int in line:
			if previous == null:
				previous = num
				continue
			var diff = previous - num
			previous = num
			if absi(diff) < 1 or absi(diff) > 3:
				isSafe = false
				break # diff is out of safe range
		if isSafe:
			safeLines += 1
	return safeLines


func solve_part2(path: String) -> int:
	return 0


func read_input(path: String) -> Array:
	var file = FileAccess.open(path, FileAccess.READ)
	var lines: Array = []
	while not file.eof_reached():
		var line: String = file.get_line()
		if line == "":
			break
		var numbers = []
		for num in line.split(" "):
			numbers.append(num as int)
		lines.append(numbers)
	return lines
