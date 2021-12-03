def inverse_bit_str(bit_str):
    result = ''
    for b in bit_str:
        result = result + str(0 if int(b) else 1)
    return result


def get_line_len(lines):
    return len(lines[0].strip())


def more_or_eq_ones(sum, total):
    return str(0 if (sum < total / 2) else 1)


def get_sums(lines):
    line_len = get_line_len(lines)
    sums = [0] * line_len
    for line in lines:
        for j in range(0, line_len):
            sums[j] = sums[j] + int(line[j])
    print(sums, len(lines))
    return sums


def part1(lines):
    sums = get_sums(lines)
    bits = ''
    for sum in sums:
        bits = bits + more_or_eq_ones(sum, len(lines))
    print(bits)
    inverse_bits = inverse_bit_str(bits)
    print(inverse_bits)
    print(int(bits, 2) * int(inverse_bits, 2))


def get_part2_line(lines, count_ones):
    lines_temp = lines
    remaining_lines = []
    for i in range(0, get_line_len(lines_temp)):
        sum = get_sums(lines_temp)[i]
        bit = more_or_eq_ones(sum, len(lines_temp))
        if count_ones:
            bit = inverse_bit_str(bit)
        for line in lines_temp:
            if line[i] == bit:
                remaining_lines.append(line)
        lines_temp = remaining_lines
        remaining_lines = []
        if len(lines_temp) <= 1:
            break
    return int(lines_temp[0], 2)


def part2(lines):
    print(get_part2_line(lines, True) * get_part2_line(lines, False))


with open('input', 'r') as f:
    part2(f.readlines())
