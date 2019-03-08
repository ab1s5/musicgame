if __name__ == "__main__":
    fi = open("symmetry.txt", 'r')

    while True:
        line = fi.readline().strip()
        if len(line) > 0:
            print(line[0], end='')

            for i in range(len(line) - 1):
                print(line[-i - 1], end='')
            print('')
