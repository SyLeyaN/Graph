using System.IO;
using System.Collections.Generic;

namespace Graphs
{
    public class Graph
    {
        private Dictionary<string, Dictionary<string, int>> AdjList=new Dictionary<string, Dictionary<string, int>>();
        private bool Weight = false;
        private bool Orientation = false;
        private int amount=0;
        public Graph()
        {
        }
        public Graph(bool w,bool o)
        {
            Weight = w;
            Orientation = o;
        }
        public Graph(string file)
        {
            using (StreamReader fileIn = new StreamReader($"C:/Users/Narut0/source/repos/Graph/Graph/{file}"))
            {
                List<string> status = new List<string>(fileIn.ReadLine().Split(" "));
                if (status.Contains("o"))
                {
                    Orientation = true;
                }
                if (status.Contains("w"))
                {
                    Weight = true;
                }
                amount = int.Parse(status[status.Count - 1]);
                if (Weight)
                {
                    for (int i = 0; i < amount; ++i)
                    {
                        List<string> tempList = new List<string>(fileIn.ReadLine().Split(" "));
                        Dictionary<string, int> tempDict = new Dictionary<string, int>();
                        if (tempList.Count > 1)
                        {
                            int countAdj = (tempList.Count - 1) / 2;
                            for (int j = 0; j < countAdj; ++j)
                            {
                                tempDict.Add(tempList[j * 2 + 1], int.Parse(tempList[j * 2 + 2]));
                            }
                        }
                        AdjList.Add(tempList[0], tempDict);
                    }
                }
                else
                {
                    for (int i = 0; i < amount; ++i)
                    {
                        List<string> tempList = new List<string>(fileIn.ReadLine().Split(" "));
                        Dictionary<string, int> tempDict = new Dictionary<string, int>();
                        for (int j = 0; j < tempList.Count - 1; ++j)
                        {
                            tempDict.Add(tempList[j + 1], 0);
                        }
                        AdjList.Add(tempList[0], tempDict);
                    }
                }
            }
        }
        public Graph(Graph obj)
        {
            for(int i = 0; i < obj.AdjList.Count; ++i)
            {
                foreach(KeyValuePair<string, Dictionary<string, int>> pair in obj.AdjList)
                {
                    AdjList.Add(pair.Key, pair.Value);
                }
            }
            Weight = obj.Weight;
            Orientation = obj.Orientation;
            amount = obj.amount;
        }
        public string addNode(string name)
        {
            string temp;
            if (AdjList.ContainsKey(name))
            {
                temp = $"Вершина с именем {name} уже существует";
            }
            else
            {
                ++amount;
                AdjList.Add(name, new Dictionary<string, int>());
                temp = $"Вершина {name} успешно добавлена";
            }
            return temp;
        }
        public string deleteNode(string name)
        {
            string temp;
            if (AdjList.ContainsKey(name))
            {
                foreach(KeyValuePair<string,Dictionary<string,int>> top in AdjList)
                {
                    top.Value.Remove(name);
                }
                AdjList.Remove(name);
                temp = $"Вершина {name} удалена";
                --amount;
            }
            else
            {
                temp = $"Вершины с названием {name} не существует";
            }
            return temp;
        }
        public string addEdje(string a, string b)
        {
            bool aCheck = AdjList.ContainsKey(a);
            bool bCheck = AdjList.ContainsKey(b);
            if (!aCheck && !bCheck)
            {
                return ($"Вершин с именами {a} и {b} не существует");
            }
            if (!aCheck)
            {
                return ($"Вершины с именем {a} не существует");
            }
            if (!bCheck)
            {
                return ($"Вершины с именем {b} не существует");
            }
            if (AdjList[a].ContainsKey(b))
            {
                if (Orientation)
                {
                    return $"Из вершины {a} в {b} уже существует дуга";
                }
                else
                {
                    return $"Между вершинами {a} и {b} уже существует ребро";
                }
            }
            if (Orientation)
            {
                AdjList[a].Add(b, 0);
                return $"Дуга из вершины {a} в {b} добавлена";
            }
            else
            {
                AdjList[a].Add(b, 0);
                AdjList[b].Add(a, 0);
                return $"Ребро между вершинами {a} и {b} добавлено";
            }
        }
        public string addEdje(string a, string b,int c)
        {
            bool aCheck = AdjList.ContainsKey(a);
            bool bCheck = AdjList.ContainsKey(b);
            if (!aCheck && !bCheck)
            {
                return ($"Вершин с именами {a} и {b} не существует");
            }
            if (!aCheck)
            {
                return ($"Вершины с именем {a} не существует");
            }
            if (!bCheck)
            {
                return ($"Вершины с именем {b} не существует");
            }
            if (AdjList[a].ContainsKey(b))
            {
                if (Orientation)
                {
                    return $"Из вершины {a} в {b} уже существует дуга";
                }
                else
                {
                    return $"Между вершинами {a} и {b} уже существует ребро";
                }
            }
            if (Orientation)
            {
                AdjList[a].Add(b, c);
                return $"Дуга из вершины {a} в {b} добавлена";
            }
            else
            {
                AdjList[a].Add(b, c);
                AdjList[b].Add(a, c);
                return $"Ребро между вершинами {a} и {b} добавлено";
            }
        }
        public string deleteEdje(string a, string b)
        {
            bool aCheck = AdjList.ContainsKey(a);
            bool bCheck = AdjList.ContainsKey(b);
            if (!aCheck && !bCheck)
            {
                return ($"Вершин с именами {a} и {b} не существует");
            }
            if (!aCheck)
            {
                return ($"Вершины с именем {a} не существует");
            }
            if (!bCheck)
            {
                return ($"Вершины с именем {b} не существует");
            }
            if (!AdjList[a].ContainsKey(b))
            {
                if (Orientation)
                {
                    return $"Из вершины {a} в {b} не существует дуги";
                }
                else
                {
                    return $"Между вершинами {a} и {b} не существует ребра";
                }
            }
            if (Orientation)
            {
                AdjList[a].Remove(b);
                return $"Дуга из вершины {a} в {b} удалена";
            }
            else
            {
                AdjList[a].Remove(b);
                AdjList[b].Remove(a);
                return $"Ребро между вершинами {a} и {b} удалено";
            }
        }
        
    }
}
