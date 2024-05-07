import math


# 2 LINES WITHOUT VALIDATING INPUT
def reverse_n_pi_digits(n : int) -> int:
    digits = str(math.pi)[:n]
    return digits[::-1]
