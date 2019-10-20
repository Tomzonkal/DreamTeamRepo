import File_reader as fr
import networkx as nx
import matplotlib.pyplot as plt

G = nx.Graph()

nodes = []
weights = []
for i in range(len(fr.nodes)):
    nodes.append(fr.nodes[i][0])
for i in range(len(fr.nodes)):
    weights.append(fr.nodes[i][-1])
# G.add_nodes_from(nodes)

for i in range(len(fr.nodes)):
    G.add_node(nodes[i], weight=weights[i])

for i in range(len(fr.nodes)):
    for j in range(len(fr.nodes[i][1])):
        G.add_edge(fr.nodes[i][0], fr.nodes[i][1][j])

nx.draw(G, with_labels=True, font_weight='bold')
plt.show()
