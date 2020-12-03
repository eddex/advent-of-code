# checks if the provided 'character' is at least 'min' times
# and at most 'max' times in the 'password'
def check_validity_part_1(min, max, character, password: str):
    matches = 0
    for c in password:
        if c == character:
            matches += 1
    return matches >= min and matches <= max


# check if the character is on position 1 or 2, not on both (XOR)
# positions are not 0 based
def check_validity_part_2(position1, position2, character, password):
    return (password[position1-1] == character) ^ (password[position2-1] == character)


# parse a string like '1-3 a: abcde' to get the individual parts
def parse_policy(input_line):
    split_line = input_line.split('-')
    first_number = int(split_line[0])
    split_line = split_line[1].split(' ')
    second_number = int(split_line[0])
    password = split_line[2]
    split_line = split_line[1].split(':')
    character = split_line[0]

    return first_number, second_number, character, password


valid_passwords_part_1 = 0
valid_passwords_part_2 = 0
with open('./input.txt') as input:
    for line in input:
        first_number, second_number, character, password = parse_policy(line)
        if check_validity_part_1(first_number, second_number, character, password):
            valid_passwords_part_1 += 1
        if check_validity_part_2(first_number, second_number, character, password):
            valid_passwords_part_2 += 1

print('Valid passwords part 1: %s' % valid_passwords_part_1)
print('Valid passwords part 2: %s' % valid_passwords_part_2)