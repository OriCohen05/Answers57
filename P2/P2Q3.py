def is_sorted_polyndrom(str: str) -> bool:
        is_sorted = True
        is_poly = str[::-1] == str
        iteration = len(str) // 2 if len(str) % 2 == 0 else len(str) // 2 + 1
        for i in range(1, iteration + 1):
            if ord(str[i]) < ord(str[i - 1]):
                is_sorted = False
                return is_sorted

        return is_sorted and is_poly


print(is_sorted_polyndrom("cbabc"))
