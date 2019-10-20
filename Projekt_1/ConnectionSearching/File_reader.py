file = open('Conections.txt')

text = file.read()
temp = text.split("*")
nodes = []
for i in temp:
    node = i.split(";")
    node[1] = node[1].split(",")
    nodes.append(node)
