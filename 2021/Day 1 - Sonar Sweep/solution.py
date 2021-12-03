def part1(lines):
    count = 0
    for i in range(0, len(lines)-1):
        if lines[i] < lines[i+1]:
            count = count + 1
    print(count)

def part2(lines):
    a = 0
    b = 1
    c = 2
    sums = []
    while c < len(lines):
        sums.append(sum([lines[i] for i in [a,b,c]]))
        a = a + 1
        b = b + 1
        c = c + 1
    part1(sums)

with open('input', 'r') as f:
    part2( [int(i) for i in f.readlines()] )