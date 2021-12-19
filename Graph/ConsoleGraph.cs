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
        public static void Ia_3(Graph graph)
        {
            System.Console.WriteLine("\nTask Ia_3:");
            graph.Ia_3();

        }
        public static void Ia_16(Graph graph, string a, string b)
        {
            Console.WriteLine("\nTask Ia_16:");
            graph.Ia_16(a, b);
        }
        public static void II_6(Graph graph)
        {
            System.Console.WriteLine("\nTask II_6:");
            graph.II_6();
        }
        public static void III(Graph graph,string a)
        {
            Console.WriteLine("\nTask III");
            graph.III(a);
        }
        public static void Ib_8(Graph a, Graph b)
        {
            Console.WriteLine("\nTask Ib_8");
            a.Ib_8(a,b);
        }       
        public static void V(Graph graph, string start, string end)
        {
            Console.WriteLine("\nTask V");
            Console.WriteLine(graph.V(start, end));
        }
        public static void II_18(Graph graph)
        {
            Console.WriteLine("\nTask II_18");
            graph.II_18();
        }
        static Graph graph;
        static int action = 0;
        public static void Start(Graph graphNew)
        {
            graph = graphNew;
            ShowMenu();
            Console.WriteLine();
            while (action != 7)
            {
                ReadKey();
                SwitchAction(action);
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("1. Добавить вершину.\n" +
                              "2. Добавить ребро.\n" +
                              "3. Удалить вершину.\n" +
                              "4. Удалить ребро.\n" +
                              "5. Показать список смежности.\n" +
                              "6. Показать меню\n" +
                              "7. Выйти из программы\n");

        }
        static void ReadKey()
        {
            Console.WriteLine("Введите номер действия, который вы хотите выполнить: ");
            try
            {
                action = int.Parse(Console.ReadLine());
            }
            catch
            {
                action = 0;
            }

        }
        static void SwitchAction(int i)
        {
            switch (i)
            {
                case (1):
                    {
                        Console.WriteLine("Введите название новой вершины: ");
                        ConsoleGraph.addNode(graph, Console.ReadLine());
                        Console.WriteLine();
                        break;
                    }
                case (2):
                    {
                        if (graph.GetWeight)
                        {
                            Console.WriteLine("Введите название двух вершин через пробел и весы(1-ая - откуда, 2-ая - куда и весы):");
                            string[] temp = Console.ReadLine().Split(" ");
                            try
                            {
                                ConsoleGraph.addEdje(graph, temp[0], temp[1], int.Parse(temp[2]));
                            }
                            catch
                            {
                                Console.WriteLine("Весы должны быть целым числом");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Введите название двух вершин через пробел (1-ая - откуда, 2-ая - куда):");
                            string[] temp = Console.ReadLine().Split(" ");
                            ConsoleGraph.addEdje(graph, temp[0], temp[1]);
                        }
                        Console.WriteLine();
                        break;
                    }
                case (3):
                    {
                        Console.WriteLine("Введите название вершины которую хотите удалить:");
                        ConsoleGraph.deleteNode(graph, Console.ReadLine());
                        Console.WriteLine();
                        break;
                    }
                case (4):
                    {
                        Console.WriteLine("Введите название двух вершин через пробел(1-ая - откуда, 2-ая - куда):");
                        string[] temp = Console.ReadLine().Split(" ");
                        ConsoleGraph.deleteEdje(graph, temp[0], temp[1]);
                        Console.WriteLine();
                        break;
                    }
                case (5):
                    {
                        Console.WriteLine();
                        ConsoleGraph.showGraph(graph);
                        Console.WriteLine();
                        break;
                    }
                case (6):
                    {
                        Console.WriteLine();
                        ShowMenu();
                        Console.WriteLine();
                        break;
                    }
                case (7):
                    {
                        Console.WriteLine();
                        Console.WriteLine("Конец");
                        Console.WriteLine();
                        break;

                    }
                default:
                    {
                        Console.WriteLine("Введено некорректное действие");
                        Console.WriteLine();
                        break;
                    }
            }
        }

        public static void IVc_8(Graph a, string Node, int n)
        {
            Console.WriteLine("\nTask IVc_8");
            a.IVc_8(a.GetAdjList, Node, n);
        }
        public static void IVb_4(Graph graph, string u, string v1, string v2)
        {
            Console.WriteLine("\nTask IVb_4");
            graph.IVb_4(u,v1,v2);
        }//Разобраться
        public static void IVa_2(Graph graph, string s)
        {
            Console.WriteLine("\nTaskIVa_2");
            graph.IVa_2(s);
        }//Разобраться
        
        
       
    }









}

