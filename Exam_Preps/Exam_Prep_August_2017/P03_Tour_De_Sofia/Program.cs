using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P03_Tour_De_Sofia
{
    class Program
    {

        private static Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

        //probably.... make all of these dictionaries, so i dont fill everything up ? 
        private static int[] distances;
        //prev are unnecessary, because you need count only!!
        //private static int[] prev;
        private static bool[] isVisited;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            //number of streets
            int countOfEdges = int.Parse(Console.ReadLine());

            //or starting street
            int startNode = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfEdges; i++)
            {
                int[] coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                Edge current = new Edge()
                {
                    Start = coordinates[0],
                    End = coordinates[1]
                };

                if (!graph.ContainsKey(current.Start))
                {
                    graph[current.Start] = new List<Edge>();
                }

                if (!graph.ContainsKey(current.End))
                {
                    graph[current.End] = new List<Edge>();
                }

                graph[current.Start].Add(current);
                graph[current.End].Add(current);


            }

            //prev = Enumerable.Repeat(-1, graph.Count).ToArray();
            distances = new int[graph.Count];
            isVisited = new bool[graph.Count];

            //here was using a bag, but perhaps it is inefficient
            Queue<int> priorityQueue = new Queue<int>();

            
            priorityQueue.Enqueue(startNode);

            while (priorityQueue.Count > 0)
            {

                var min = priorityQueue.Dequeue();
                foreach (var child in graph[min])
                {
                    //this should take care of the pointers? 
                    if (min==child.End)
                    {
                        continue;
                    }

                    var otherNode = child.Start == min
                        ? child.End
                        : child.Start;




                    var newDistance = distances[min] + 1;
                    if (!isVisited[otherNode])
                    {
                        isVisited[otherNode] = true;
                        priorityQueue.Enqueue(otherNode);
                        distances[otherNode] = newDistance;
                        //prev[otherNode] = min;
                    }

                    //                          +1, because they don`t have weights!
                    if (distances[otherNode] > newDistance)
                    {
                        distances[otherNode] = newDistance;
                        //prev[otherNode] = min;
                    }

                }


            }

            


            if (isVisited[startNode])
            {
                var result = new List<int>();

                var current = startNode;

                do
                {
                    result.Add(current);
                    //current = prev[current];

                } while (current!=startNode);

                Console.WriteLine(distances[startNode]);

                result.Reverse();
            }
            else
            {
                //then we`ll print every visited node (the count i think?)
                var result = isVisited.Where(x => x == true).Count();
                
                //+ 1, because it marks itself too? 
                Console.WriteLine(result+1);
                
            }
        }


    }

    public class Edge
    {
        public int Start { get; set; }

        public int End { get; set; }

    }
}
