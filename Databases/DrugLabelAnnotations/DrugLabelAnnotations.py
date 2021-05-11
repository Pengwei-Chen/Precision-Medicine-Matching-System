import re
input = open("DrugLabelAnnotations.txt")
output = open("DrugLabelAnnotationsOutput.txt","w")
input_line = input.readline()
while(input_line):
    if(re.match("PA",input_line)!=None):
        list = []
        for i in range(4):
            list.append(input_line.strip("\n"))
            input_line = input.readline()
        output_line = '("' + list[0] + '","' + list[1] + '",' + list[2] + ',"' + list[3] + '"),\n'
        output.write(output_line)
    input_line = input.readline()
input.close()
output.close()