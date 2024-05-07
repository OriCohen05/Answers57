import matplotlib.pyplot as plt


def process_sequence():
    """
    Process a sequence of numbers and returns data based on the requirements
    """
    numbers = []
    x_coords = []

    num = int(input("Enter number: "))
    while num != -1:
        numbers.append(num)
        x_coords.append(len(numbers) - 1)
        num = int(input("Enter number: "))

    if numbers:
        positive_numbers = [x for x in numbers if x > 0]

        print(f'---------------\n'
              f'Input numbers data:\n'
              f'Average: {sum(numbers) / len(numbers)}\n'
              f'Positive: {len(positive_numbers)}\n'
              f'Sorted: {sorted(numbers)}')
        plt.scatter(x_coords, numbers)

        plt.xlabel('Input Order')
        plt.ylabel('Number')
        plt.title('Number Sequence (Plot)')
        plt.xlim(-0.5, len(numbers))  # -0.5 for visualization clarity
        plt.show()
    else:
        print("No numbers were entered to display a graph")


process_sequence()
