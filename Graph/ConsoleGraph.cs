using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    static class ConsoleGraph
    {
        static void addNode(Graph graph, string name)
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
        static void deleteNode(Graph graph, string name)
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
        static void addEdje(Graph graph, string a, string b)
        {
            bool aCheck = graph.GetAdjList.ContainsKey(a);
            bool bCheck = graph.GetAdjList.ContainsKey(b);
            string temp;
            if (!aCheck && !bCheck)
            {
                temp = ($"Вершин с именами {a} и {b} не существует");
            }
            if (!aCheck)
            {
                temp = ($"Вершины с именем {a} не существует");
            }
            if (!bCheck)
            {
                temp = ($"Вершины с именем {b} не существует");
            }
            if (graph.GetAdjList[a].ContainsKey(b))
            {
                if (graph.GetOrientation)
                {
                    temp = $"Из вершины {a} в {b} уже существует дуга";
                }
                else
                {
                    temp = $"Между вершинами {a} и {b} уже существует ребро";
                }
            }
            if (graph.GetOrientation)
            {
                graph.addEdjeOr(a, b);
                temp = $"Дуга из вершины {a} в {b} добавлена";
            }
            else
            {
                graph.addEdje(a, b);
                temp = $"Ребро между вершинами {a} и {b} добавлено";
            }
            Console.WriteLine(temp);
        }
        static void addEdje(Graph graph, string a, string b, int c)
        {
            bool aCheck = graph.GetAdjList.ContainsKey(a);
            bool bCheck = graph.GetAdjList.ContainsKey(b);
            string temp;
            if (!aCheck && !bCheck)
            {
                temp = ($"Вершин с именами {a} и {b} не существует");
            }
            if (!aCheck)
            {
                temp = ($"Вершины с именем {a} не существует");
            }
            if (!bCheck)
            {
                temp = ($"Вершины с именем {b} не существует");
            }
            if (graph.GetAdjList[a].ContainsKey(b))
            {
                if (graph.GetOrientation)
                {
                    temp = $"Из вершины {a} в {b} уже существует дуга";
                }
                else
                {
                    temp = $"Между вершинами {a} и {b} уже существует ребро";
                }
            }
            if (graph.GetOrientation)
            {
                graph.addEdjeOr(a, b, c);
                temp = $"Дуга из вершины {a} в {b} добавлена";
            }
            else
            {
                graph.addEdje(a, b, c);
                temp = $"Ребро между вершинами {a} и {b} добавлено";
            }
            Console.WriteLine(temp);
        }
        static void deleteEdje(Graph graph, string a, string b)
        {
            bool aCheck = graph.GetAdjList.ContainsKey(a);
            bool bCheck = graph.GetAdjList.ContainsKey(b);
            string temp;
            if (!aCheck && !bCheck)
            {
                temp = ($"Вершин с именами {a} и {b} не существует");
            }
            if (!aCheck)
            {
                temp = ($"Вершины с именем {a} не существует");
            }
            if (!bCheck)
            {
                temp = ($"Вершины с именем {b} не существует");
            }
            if (!graph.GetAdjList[a].ContainsKey(b))
            {
                if (graph.GetOrientation)
                {
                    temp = $"Из вершины {a} в {b} не существует дуги";
                }
                else
                {
                    temp = $"Между вершинами {a} и {b} не существует ребра";
                }
            }
            if (graph.GetOrientation)
            {
                graph.deleteEdjeOr(a, b);
                temp = $"Дуга из вершины {a} в {b} удалена";
            }
            else
            {
                graph.deleteEdje(a, b);
                temp = $"Ребро между вершинами {a} и {b} удалено";
            }
            Console.WriteLine(temp);
        }

    }
}
