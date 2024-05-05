def is_sorted_polyndrom(text: str) -> bool:
        is_sorted = True
        is_poly = str[::-1] == text
        iteration = len(text) // 2
        for i in range(1, iteration + 1):
            if ord(text[i]) < ord(text[i - 1]):
                return False

        return is_sorted and is_poly
