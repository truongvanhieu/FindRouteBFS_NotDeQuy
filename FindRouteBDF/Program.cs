using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRouteBDF
{
    public class BDF
    {
        private static Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();

        public void printpath(List<int> path)
        {
            Console.WriteLine(String.Join("-->", path));
        }

        // utility function to check if current 
        // vertex is already present in path 
        public int isNotVisited(int x, List<int> path)
        {
            foreach (var item in path)
            {
                if (item == x)
                {
                    return 0;
                }
            }
            return 1;
        }

        // utility function for finding paths in graph 
        // from source to destination 
        public void findpaths(int src, int dst, int v)
        {
            // create a queue which stores 
            // the paths 
            Queue<List<int>> q = new Queue<List<int>>();

            // path vector to store the current path 
            List<int> path = new List<int>();
            path.Add(src);

            q.Enqueue(path);
            while (q.Count() > 0)
            {
                path = q.Dequeue();
                int last = path.ElementAt(path.Count - 1);

                // if last vertex is the desired destination 
                // then print the path 
                if (last == dst)
                    printpath(path);

                // traverse to all the nodes connected to  
                // current vertex and push new path to queue 
                List<int> lst = new List<int>();
                if (g.TryGetValue(last, out lst))
                {
                   for (int i = 0; i < lst.Count(); i++)
                    {
                        if (isNotVisited(lst.ElementAt(i), path) > 0)
                        {
                            List<int> newpath = new List<int>(path);
                            newpath.Add(lst.ElementAt(i));
                            q.Enqueue(newpath);
                        }
                    } 
                }

                
                
            }
        }

        // add edge from u to v  --> u: busstop, v:bustop next
        public void addEdge(int u, List<int> v)
        {
            g.Add(u, v);
        }
    }
    public class MainABC
    {
        static void Main(string[] args)
        {
            BDF bdf = new BDF();
            bdf.addEdge(0, new List<int>{1,2,3 });//add canh
            bdf.addEdge(1, new List<int> { 3 });
            bdf.addEdge(2, new List<int> { 0, 1 });
            
            int src = 2, dst = 3;
            // function for finding the paths 
            bdf.findpaths(src, dst, 4);
        }

    }
}
