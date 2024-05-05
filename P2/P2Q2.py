import math


def pythagorean_triplet_by_sum(sum: int):
    """
    :param sum: The target sum for which to find Pythagorean triplets.
    :prints: Pythagorean triplets for a given sum.
  """

    if not isinstance(sum, int) or sum < 3:
        print("Please enter a positive integer greater than or equal to 3.")
        return

    a_list = []
    b_list = []
    c_list = []
    found_c_set = set()

    for a in range(1, sum - 2):
        for b in range(a + 1, sum - 1):
            if sum ** 2 - a ** 2 - b ** 2 >= 0:
                c = math.sqrt(sum ** 2 - a ** 2 - b ** 2)
                if isinstance(c, int):
                    if c not in found_c_set:
                        found_c_set.add(c)
                        a_list.append(a)
                        b_list.append(b)
                        c_list.append(c)
    a_list.sort()
    b_list.sort()
    c_list.sort()

    for i in range(len(a_list)):
        print(f"{a_list[i]} < {b_list[i]} < {c_list[i]}")


pythagorean_triplet_by_sum(12)
