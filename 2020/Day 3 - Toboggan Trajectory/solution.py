# traverse the 'map' starting at the top-left and moving
# 'down_steps' down and 'side_steps' right every move
def calculate_encountered_trees(side_steps, down_steps, map):
    trees_encountered = 0
    index_y = 0
    max_y = len(arr) - 1
    index_x = 0
    max_x = len(arr[0])

    while index_y <= max_y:
        trees_encountered += map[index_y][index_x]
        index_y += down_steps
        index_x = (index_x + side_steps) % max_x

    return trees_encountered

arr = []
with open('./input.txt') as input:
    for line in input:
        # remove newline and replace '.' (empty space) with 0 and '#' (tree) with 1
        parsed_line = line.split('\n')[0].replace('.', '0').replace('#', '1')
        # append to array as int array
        arr.append([int(num) for num in parsed_line])

print('trees encountered (part 1): %s' % calculate_encountered_trees(3, 1, arr))

result_part_2 = calculate_encountered_trees(1, 1, arr)
result_part_2 *= calculate_encountered_trees(3, 1, arr)
result_part_2 *= calculate_encountered_trees(5, 1, arr)
result_part_2 *= calculate_encountered_trees(7, 1, arr)
result_part_2 *= calculate_encountered_trees(1, 2, arr)

print('result part 2: %s' % result_part_2)

