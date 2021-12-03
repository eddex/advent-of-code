def part1(lines):
    h_pos = 0
    depth = 0
    for line in lines:
        k, v = line.split(' ')
        if k == 'forward':
            h_pos = h_pos + int(v)
        else:
            depth = depth - int(v) if k == 'up' else depth + int(v)
    print(h_pos * depth)

def part2(lines):
    aim = 0
    h_pos = 0
    depth = 0
    for line in lines:
        k, v = line.split(' ')
        if k == 'forward':
            h_pos = h_pos + int(v)
            depth = depth + aim * int(v)
        else:
            aim = aim - int(v) if k == 'up' else aim + int(v)
    print(h_pos * depth)


with open('input', 'r') as f:
    part2(f.readlines())