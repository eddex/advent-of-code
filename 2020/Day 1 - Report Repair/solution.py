import numpy as np


# binary search that searches for the index in the sorted array
# where the sum of the current item and the first_value param
# are equal to the sum param
def search_for_pair_by_sum(sorted_array, sum, first_value):
    left_index = 0
    right_index = sorted_array.size - 1

    while left_index < right_index:

        # to avoid integer overflows, we can't just use (left + right) / 2
        middle_index = int(left_index + ((right_index - left_index) / 2))

        result = sorted_array[middle_index] + first_value
        if result == sum:
            # found a match!
            return middle_index
        elif result > sum:
            # search in left part with the smaller numbers
            right_index = middle_index - 1
        else:
            # search in right part with the bigger numbers
            left_index = middle_index + 1

    return -1


data = np.loadtxt('./input.txt', dtype='int', delimiter='\n')
data.sort()

for i in range(data.size):
    search_result_index = search_for_pair_by_sum(data, 2020, data[i])
    if search_result_index != -1:
        print('--- part 1 ---')
        print("%s + %s = 2020" % (data[i], data[search_result_index]))
        print("%s * %s = %s\n" % (data[i], data[search_result_index], data[i] * data[search_result_index]))


    for j in range(data.size):
        search_result_index = search_for_pair_by_sum(data, 2020, data[i] + data[j])
        if search_result_index != -1:
            print('--- part 2 ---')
            print("%s + %s + %s = 2020" % (data[i], data[j], data[search_result_index]))
            print("%s * %s * %s = %s\n" % (
                data[i], data[j], data[search_result_index], data[i] * data[j] * data[search_result_index]))
