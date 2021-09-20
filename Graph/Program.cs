using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph temp = new Graph("graph_0.txt");
            ConsoleGraph.deleteNode(temp, "e");
            ConsoleGraph.addNode(temp, "new");
            ConsoleGraph.addNode(temp, "old");
            ConsoleGraph.addEdje(temp, "b", "new", 4);
            ConsoleGraph.addEdje(temp, "b", "new", 4);
            ConsoleGraph.deleteEdje(temp, "b", "new");
            temp.saveGraph("test.txt");
            ConsoleGraph.showGraph(temp);
        }
    }
}
