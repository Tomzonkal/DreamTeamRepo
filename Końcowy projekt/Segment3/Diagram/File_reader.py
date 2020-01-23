import json


def read(filename):
    with open(filename, 'r') as handle:
        parsed = json.load(handle)

    nodes = []

    for node in parsed:
        nodes.append(node)

    return nodes
