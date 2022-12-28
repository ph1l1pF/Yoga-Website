import requests
import json
import os
import matplotlib.pyplot as plt
import numpy as np



def convert_string_to_json(string):
    return json.loads(string)

def sort_by_date(json_data):
    return sorted(json_data, key=lambda k: k['date'])


# create a bar chart with the component name and the number of visits
def create_bar_chart(json):

    # create a list of the number of visits
    visit_counts = {}
    for elem in json:
        if elem['componentName'] is not None:
            if visit_counts.get(elem['componentName']) is None:
                # unicode to string
                visit_counts[str(elem['componentName'])] = 1
            else:
                visit_counts[str(elem['componentName'])] += 1

    # create a dictionary with the component names and the number of visits
    data = visit_counts

    # create a bar chart
    y_pos = np.arange(len(data.keys()))
    plt.bar(y_pos, data.values())
    plt.xticks(y_pos, data.keys())
    plt.show()

r =requests.get('http://116.203.44.102:82/usagedata/getallvisits') 
json = convert_string_to_json(r.text)
json = sort_by_date(json)
create_bar_chart(json)
    




