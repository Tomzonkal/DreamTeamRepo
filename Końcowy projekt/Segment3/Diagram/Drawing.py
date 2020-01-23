# -*- coding: utf-8 -*- 
import File_reader as fr
import networkx as nx
import matplotlib.pyplot as plt


G = nx.DiGraph()
nodes = fr.read('input.jason')

names = []
weights = {}
connections = []

# nazwy węzłów
for node in nodes:
    names.append(node['name'])

# wagi węzłów - rozmiary plików
for node in nodes:
    weights[node['name']] = node['size']

# połączenia z innymi plikami
for node in nodes:
    connections.append(node['connections'])

# wrzucamy węzły zawierające nazwy plików do grafu
G.add_nodes_from(names)

# Tworzymy listę połączeń między węzłami (krawędzie)
edges = []
for i in range(len(names)):
    for connected_node in connections[i]:
        if connected_node == '':
            continue
        edge = (names[i], connected_node)
        edges.append(edge)

# Wrzucamy krawędzie do grafu
G.add_edges_from(edges)
