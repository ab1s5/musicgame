current_time = 0
bar = 0 # 마디당 시간(ms)
note = []
instruction = []

beat8th = [1.0/2]
beat16th = [1.0/4, 3.0/4]
beat12th = [1.0/3, 2.0/3]
beat24th = [1.0/6, 5.0/6]


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
                        fo.write(str(int(round(current_time))) + ',' + str(360.0 / len(note[i]) * j))
                        ratio = i / len(note)
                        if ratio == 0:
                            fo.write(",r\n")
                        elif ratio in beat8th:
                            fo.write(",b\n")
                        elif ratio in beat16th:
                            fo.write(",y\n")
                        elif ratio in beat12th:
                            fo.write(",g\n")
                        elif ratio in beat24th:
                            fo.write(",m\n")
                        else:
                            fo.write(",x\n")

                current_time += bar / len(note)

    fi.close()
    fo.close()

