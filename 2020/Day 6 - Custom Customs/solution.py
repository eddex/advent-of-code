def read_input(path = './input.txt'):
    groups = []
    with open(path) as f:
        group = []
        while True:
            line = f.readline()
            if line == '' or line == '\n' or line == '\r\n':
                groups.append(group)
                group = []
                if line == '':
                    break
            else:
                group.append(line.strip('\n'))
    return groups


#groups = read_input('./input_test.txt')
groups = read_input()

count = 0
count2 = 0
for group in groups:
    group_answers_dict = {}
    for answers in group:
        for answer in answers:
            if not answer in group_answers_dict:
                group_answers_dict[answer] = 1
            else:
                group_answers_dict[answer] += 1
    count += len(group_answers_dict)
    for k, v in group_answers_dict.items():
        if v == len(group):
            count2 += 1

print('part 1: %s' % count)
print('part 2: %s' % count2)
