using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph temp = new Graph("graph_5.txt");
            /*ConsoleGraph.deleteNode(temp, "e");
            ConsoleGraph.addNode(temp, "new");
            ConsoleGraph.addNode(temp, "old");
            ConsoleGraph.addEdje(temp, "b", "new", 4);
            ConsoleGraph.addEdje(temp, "b", "new", 4);
            ConsoleGraph.deleteEdje(temp, "b", "new");
            temp.saveGraph("test.txt");
            ConsoleGraph.showGraph(temp);
            ConsoleGraph.Ia_3(temp);//graph_0
            ConsoleGraph.Ia_16(temp, "b", "d");*/ //graph_3
            //ConsoleGraph.II_6(temp); // graph_4
            //ConsoleGraph.III(temp, "a"); // graph_5
            Graph graph_2 = new Graph("graph_2.txt");
            Graph graph_6 = new Graph("graph_6.txt");
            ConsoleGraph.Ib_8(graph_2, graph_6);//graph_2, graph_6
            
        }
    }
}
