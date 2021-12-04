using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    static class ConsoleGraph
    {
        public static void addNode(Graph graph, string name)
        {
            string temp;
            if (graph.GetAdjList.ContainsKey(name))
            {
                temp = $"Вершина с именем {name} уже существует";
            }
            else
            {
                graph.addNode(name);
                temp = $"Вершина {name} успешно добавлена";
            }
            Console.WriteLine(temp);
        }
        public static void deleteNode(Graph graph, string name)
        {
            string temp;
            if (graph.GetAdjList.ContainsKey(name))
            {
                graph.deleteNode(name);
                temp = $"Вершина {name} удалена";
            }
            else
            {
                temp = $"Вершины с названием {name} не существует";
            }
            Console.WriteLine(temp);
        }
        public static void addEdje(Graph graph, string a, string b)
        {
            bool aCheck = graph.GetAdjList.ContainsKey(a);
            bool bCheck = graph.GetAdjList.ContainsKey(b);
            if (!aCheck && !bCheck)
            {
                Console.WriteLine($"Вершин с именами {a} и {b} не существует");
                return;
            }
            if (!aCheck)
            {
                Console.WriteLine($"Вершины с именем {a} не существует");
                return;
            }
            if (!bCheck)
            {
                Console.WriteLine($"Вершины с именем {b} не существует");
                return;
            }
            if (graph.GetAdjList[a].ContainsKey(b))
            {
                if (graph.GetOrientation)
                {
                    Console.WriteLine($"Из вершины {a} в {b} уже существует дуга");
                    return;
                }
                else
                {
                    Console.WriteLine($"Между вершинами {a} и {b} уже существует ребро");
                    return;
                }
            }
            if (graph.GetOrientation)
            {
                graph.addEdjeOr(a, b);
                Console.WriteLine($"Дуга из вершины {a} в {b} добавлена");
                return;
            }
            else
            {
                graph.addEdje(a, b);
                Console.WriteLine($"Ребро между вершинами {a} и {b} добавлено");
                return;
            }
        }
        public static void addEdje(Graph graph, string a, string b, int c)
        {
            bool aCheck = graph.GetAdjList.ContainsKey(a);
            bool bCheck = graph.GetAdjList.ContainsKey(b);
            if (!aCheck && !bCheck)
            {
                Console.WriteLine($"Вершин с именами {a} и {b} не существует");
                return;
            }
            if (!aCheck)
            {
                Console.WriteLine($"Вершины с именем {a} не существует");
                return;
            }
            if (!bCheck)
            {
                Console.WriteLine($"Вершины с именем {b} не существует");
                return;
            }
            if (graph.GetAdjList[a].ContainsKey(b))
            {
                if (graph.GetOrientation)
                {
                    Console.WriteLine($"Из вершины {a} в {b} уже существует дуга");
                    return;
                }
                else
                {
                    Console.WriteLine($"Между вершинами {a} и {b} уже существует ребро");
                    return;
                }
            }
            if (graph.GetOrientation)
            {
                graph.addEdjeOr(a, b, c);
                Console.WriteLine($"Дуга из вершины {a} в {b} добавлена");
                return;
            }
            else
            {
                graph.addEdje(a, b, c);
                Console.WriteLine($"Ребро между вершинами {a} и {b} добавлено");
                return;
            }
        }
        public static void deleteEdje(Graph graph, string a, string b)
        {
            bool aCheck = graph.GetAdjList.ContainsKey(a);
            bool bCheck = graph.GetAdjList.ContainsKey(b);
            string temp;
            if (!aCheck && !bCheck)
            {
                Console.WriteLine($"Вершин с именами {a} и {b} не существует");
                return;
            }
            if (!aCheck)
            {
                Console.WriteLine($"Вершины с именем {a} не существует");
                return;
            }
            if (!bCheck)
            {
                Console.WriteLine($"Вершины с именем {b} не существует");
                return;
            }
            if (!graph.GetAdjList[a].ContainsKey(b))
            {
                if (graph.GetOrientation)
                {
                    Console.WriteLine($"Из вершины {a} в {b} не существует дуги");
                    return;
                }
                else
                {
                    Console.WriteLine($"Между вершинами {a} и {b} не существует ребра");
                    return;
                }
            }
            if (graph.GetOrientation)
            {
                graph.deleteEdjeOr(a, b);
                Console.WriteLine($"Дуга из вершины {a} в {b} удалена");
                return;
            }
            else
            {
                graph.deleteEdje(a, b);
                Console.WriteLine($"Ребро между вершинами {a} и {b} удалено");
                return;
            }
        }
        public static void showGraph(Graph graph)
        {
            bool Weight = graph.GetWeight;
            bool Orientation = graph.GetOrientation;
            int amount = graph.GetAmount;
            string temp="";
            if (Orientation)
            {
                temp += "o ";
                if (Weight)
                {
                    temp += "w ";
                }
                temp += $"{amount}";
            }
            else
            {
                if (Weight)
                {
                    temp += "w ";
                }
                temp += $"{amount}";
            }
            Console.WriteLine(temp);
            if (Weight)
            {
                foreach (KeyValuePair<string,Dictionary<string,int>> top in graph.GetAdjList)
                {
                    temp = "";
                    temp += top.Key;
                    foreach (KeyValuePair<string,int> adjTop in top.Value )
                    {
                        temp += $" {adjTop.Key} {adjTop.Value}";
                    }
                    Console.WriteLine(temp);
                }
            }
            else
            {
                foreach (KeyValuePair<string, Dictionary<string, int>> top in graph.GetAdjList)
                {
                    temp = "";
                    temp += top.Key;
                    foreach (KeyValuePair<string, int> adjTop in top.Value)
                    {
                        temp += $" {adjTop.Key}";
                    }
                    Console.WriteLine(temp);
                }
            }
        }
        public static void Ia(Graph graph)
        {
            System.Console.WriteLine("\nTask Ia:");
            graph.Ia();

        }

    }
}
