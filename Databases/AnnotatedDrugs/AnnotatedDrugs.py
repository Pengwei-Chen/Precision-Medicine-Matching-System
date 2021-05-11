input = open("AnnotatedDrugs.csv")
output = open("AnnotatedDrugsOutput.txt","w")
input_line = input.readline()
while(input_line):
    list = input_line.split(",")
    output_line = "('" + list[0] + "','" + list[1] + "','" + list[2] + "'," + list[3] + "),"
    output.write(output_line)
    input_line = input.readline()
input.close()