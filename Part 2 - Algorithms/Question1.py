def num_len(num: int) -> int:
    """
    :param num: Natural number
    :return: num's length (amount of characters)
    """
    count = 0
    while num != 0:
        count += 1
        num //= 10
    return count
