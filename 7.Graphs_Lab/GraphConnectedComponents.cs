using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{

    
    static List<int>[] graph = new List<int>[]
    {
        new List<int>() { 3, 6 },
        new List<int>() { 3, 4, 5, 6 },
        new List<int>() { 8 },
        new List<int>() { 0, 1, 5 },
        new List<int>() { 1, 6 },
        new List<int>() { 1, 3 },
        new List<int>() { 0, 1, 4 },
        new List<int>() { },
        new List<int>() { 2 }
    };

    static bool[] isVisited ;

    public static void Main()
    {
        //isVisited = new bool[graph.Count()];
        //DFS(0);
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }

        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        //we`ll need re-initialization of visited matrix, so we can check them once more!

        isVisited = new bool[graph.Length];

        //we`ll loop through each node, just to check if some are not connected
        //after the first it will mark all THE CONNECTED elements (after the dfs)(only non-connected will be left
        for (int currentNode = 0; currentNode < graph.Count(); currentNode++)
        {
            if (!isVisited[currentNode])
            {
                Console.Write("Connected component:");
                //the dfs will visi all of the connected nodes, if they are linked.
                DFS(currentNode);
                Console.WriteLine();
            }
        }
    }

   
    private static void DFS(int vertex)
    {
        if (!isVisited[vertex])
        {
            isVisited[vertex] = true;
            foreach (var v in graph[vertex])
            {
                DFS(v);
            }
            Console.Write(" " + vertex);
        }
    }
}
