extends Node
class_name Day1


func solve_part1(path: String) -> int:
	var input = read_input(path)
	var arr1: Array = input[0]
	var arr2: Array = input[1]
	var result: int = 0
	for i in arr1.size():
		var distance = absi(arr1[i] - arr2[i])
		result += distance
	return result


func solve_part2(path: String) -> int:
	var input = read_input(path)
	var arr1: Array = input[0]
	var arr2: Array = input[1]
	var score: int = 0
	for left in arr1:
		for right in arr2:
			if left == right:
				score += left
	return score


func read_input(path: String) -> Array:
	var file = FileAccess.open(path, FileAccess.READ)
	var arr1: Array = []
	var arr2: Array = []
	while not file.eof_reached():
		var line: String = file.get_line()
		if line == "":
			break
		var splitLine: Array = line.split("   ")
		arr1.append(splitLine[0] as int)
		arr2.append(splitLine[1] as int)
	arr1.sort()
	arr2.sort()
	return [arr1, arr2]
