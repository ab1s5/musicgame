current_time: float = 0
bar: float = 0 # 마디당 시간(ms)
note = []
instruction = []


if __name__ == "__main__":
    fi = open("rawnote.txt", 'r')
    fo = open("convertednote.txt", 'w')

    while True:
        line = fi.readline().strip()
        print(line)
        instruction = line.split()
        if not instruction:
            break
        elif "delay" == instruction[0]:
            current_time += float(instruction[1])
        elif "bpm" == instruction[0]:
            bar = 60000.0 / float(instruction[1])
        elif "---" == instruction[0]:
            note = []
            noteline = fi.readline().strip()
            while "---" != noteline:
                note.append(noteline)
                noteline = fi.readline().strip()
            for i in range(len(note)):
                for j in range(len(note[i])):
                    if 'O' == note[i][j]:
                        fo.write(str(int(round(current_time))) + ',' + str(360.0 / len(note[i]) * j) + '\n')
                current_time += bar / len(note)

    fi.close()
    fo.close()

