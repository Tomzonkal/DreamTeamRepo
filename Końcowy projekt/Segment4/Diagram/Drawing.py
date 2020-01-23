# -*- coding: utf-8 -*- 
import networkx as nx
import matplotlib.pyplot as plt
import json

G = nx.DiGraph()

with open('input.json', 'r') as handle:
    files = json.load(handle)

file_names = []
functions_lists = []
function_names = []
nodes = []
edges = []

for file in files:
    file_names.append(file)
    nodes.append(file)
    functions_lists.append(files[file])

for i, functions_list in enumerate(functions_lists):
    for function in functions_list:
        if function not in nodes:
            nodes.append(function)
        edge = (function, file_names[i])
        edges.append(edge)

# Wrzucamy węzły do grafu
G.add_nodes_from(nodes)

# Wrzucamy krawędzie do grafu
G.add_edges_from(edges)

pos = nx.spring_layout(G, k=1)
nx.draw(G, pos, with_labels=True, node_size=1500, node_shape='s', font_size=5, font_weight='bold')

# rysowanie
plt.axis('off')
plt.savefig('diagram_3.png')  # zapisywanie do pliku
plt.show()
