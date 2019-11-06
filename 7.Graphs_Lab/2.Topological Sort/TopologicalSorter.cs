using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    private Dictionary<string, int> predecessorsCount;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    private void GetPredecessorCount(Dictionary<string, List<string>> graph)
    {
        //this needs to be set here, becaues it will be re-counted every time! 
        predecessorsCount = new Dictionary<string, int>();

        foreach (var node in graph)
        {
            if (!predecessorsCount.ContainsKey(node.Key))
            {
                predecessorsCount.Add(node.Key, 0);
            }

            foreach (var child in node.Value)
            {
                //???
                if (!predecessorsCount.ContainsKey(child))
                {
                    predecessorsCount[child] = 0;
                }

                predecessorsCount[child]++;
            }

        }
    }

    public ICollection<string> TopSort()
    {
        List<string> sorted = new List<string>();
        //it seems i`m abusing this too much :D 
        // i should probably remove them by hand,  not re-create a new dictionary :D 
        GetPredecessorCount(graph);
        while (true)
        {
            string nodeToRemove = predecessorsCount.Keys.Where(x => predecessorsCount[x] == 0)
                .FirstOrDefault();

            if (nodeToRemove is null)
            {
                break;
            }

            var predecessorsToRemove = graph[nodeToRemove];

            //we can abuse the above method, but it gets heavy :D 
            foreach (var predecessor in predecessorsToRemove)
            {
                predecessorsCount[predecessor]--;
            }
            
            graph.Remove(nodeToRemove);
            predecessorsCount.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);
        }

        //here is the check, if we got cycles within the graph ! 
        if (graph.Count > 0)
        {
            throw new InvalidOperationException();
        }

        return sorted;
    }
}

