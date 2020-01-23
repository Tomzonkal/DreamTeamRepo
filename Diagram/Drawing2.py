import File_reader as fr
import networkx as nx
import matplotlib.pyplot as plt

G = nx.DiGraph()
modules = fr.read('input_2.json')

module_names = []
functions_list = []
function_names = []
recallers = []
nodes = []
edges = []


for module in modules:
    module_names.append(module['name'])  # Dodajemy moduł do grupy węzłów
    nodes.append(module['name'])
    functions_list.append(module['functions'])
    recallers.append(module['odwolywujÄ…cy'])


# Tworzymy połączenia między funckją i modułem, w którym funkcja się znajduje
for i, functions in enumerate(functions_list):
    for function_name in functions:
        nodes.append(function_name)  # Dodajemy funkcję do grupy węzłów
        edge = (function_name, module_names[i])
        edges.append(edge)

# Tworzymy połączenia między modułami
for i, name in enumerate(module_names):
    for name2 in recallers[i].split():
        if (" "+name2+"\r") != name and (" "+name2+"\r") in module_names:
            edge = ((" "+name2+"\r"), name)
            edges.append(edge)

# Wrzucamy węzły do grafu
G.add_nodes_from(nodes)

# Wrzucamy krawędzie do grafu
G.add_edges_from(edges)

pos = nx.spring_layout(G, k=1)
nx.draw(G, pos, with_labels=True, node_size=3000, node_shape='s', font_size=15, font_weight='bold')

# rysowanie
plt.axis('off')
plt.savefig('diagram_2.png')  # zapisywanie do pliku
plt.show()
