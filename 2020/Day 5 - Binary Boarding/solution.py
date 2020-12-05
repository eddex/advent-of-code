def get_row_and_col(row_max_index, col_max_index, input):
    row_left_index = 0
    row_right_index = row_max_index
    col_left_index = 0
    col_right_index = col_max_index

    row = binary_search(row_left_index, row_right_index, input[0:7])
    col = binary_search(col_left_index, col_right_index, input[7:10])

    return row, col


def binary_search(left_index, right_index, input):
    for c in input:

        middle_index = int(left_index + ((right_index - left_index) / 2))
        if c in ['F', 'L']:
            # seat is in the front/left part
            right_index = middle_index
        else:
            # seat is in the back/right part
            left_index = middle_index

    return right_index


def read_boarding_passes(file_path = './input.txt'):
    with open(file_path) as f:
        return [l.rstrip("\n") for l in f]


def read_test_boarding_passes():
    return read_boarding_passes('./input_test.txt')


def get_boarding_pass_id(row, col):
    return row * 8 + col


highest_boarding_pass_id = 0
all_boarding_pass_ids = []
for boarding_pass in read_boarding_passes():
    row, col = get_row_and_col(127, 7, boarding_pass)
    id = get_boarding_pass_id(row, col)
    all_boarding_pass_ids.append(id)
    if id > highest_boarding_pass_id:
        highest_boarding_pass_id = id

# part 1
print('highest boarding pass id: %s' % highest_boarding_pass_id)

# part 2
all_boarding_pass_ids.sort()
previous_id = all_boarding_pass_ids[0]
for id in all_boarding_pass_ids:
    if id - previous_id > 1:
        print('my seat is between %s and %s: %s' % (previous_id, id, id-1))
    previous_id = id
