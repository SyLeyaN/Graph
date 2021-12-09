using System.IO;
using System.Collections.Generic;

namespace Graphs
{
    public class Graph
    {
        private Dictionary<string, Dictionary<string, int>> AdjList = new Dictionary<string, Dictionary<string, int>>();
        private bool Weight = false;
        private bool Orientation = false;
        private int amount = 0;
        
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
            using (StreamReader fileIn = new StreamReader($"C:/Код/DZ/Graph/Graph/Graphs/{file}"))
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
            foreach (KeyValuePair<string, Dictionary<string, int>> pair in obj.AdjList)
            {
                Dictionary<string, int> temp = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> smej in pair.Value)
                {
                    temp.Add(smej.Key, smej.Value);
                }
                AdjList.Add(pair.Key, temp);
            }

            Weight = obj.Weight;
            Orientation = obj.Orientation;
            amount = obj.amount;
        }
        public void saveGraph(string file)
        {
            using (StreamWriter fileOut = new StreamWriter($"E:/Код/Homework/Graph/Graph/Graphs/Save/{file}"))
            {
                string temp = "";
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
                fileOut.WriteLine(temp);
                if (Weight)
                {
                    foreach (KeyValuePair<string, Dictionary<string, int>> top in AdjList)
                    {
                        temp = "";
                        temp += top.Key;
                        foreach (KeyValuePair<string, int> adjTop in top.Value)
                        {
                            temp += $" {adjTop.Key} {adjTop.Value}";
                        }
                        fileOut.WriteLine(temp);
                    }
                }
                foreach (KeyValuePair<string, Dictionary<string, int>> top in AdjList)
                {
                    temp = "";
                    temp += top.Key;
                    foreach (KeyValuePair<string, int> adjTop in top.Value)
                    {
                        temp += $" {adjTop.Key}";
                    }
                    fileOut.WriteLine(temp);
                }
            }
        }
        public void addNode(string name)
        {           
                ++amount;
                AdjList.Add(name, new Dictionary<string, int>());
        }
        public void deleteNode(string name)
        {
            foreach (KeyValuePair<string, Dictionary<string, int>> top in AdjList)
            {
                top.Value.Remove(name);
            }
            AdjList.Remove(name);
            --amount;
        }
        public void addEdje(string a, string b)
        {
            AdjList[a].Add(b, 0);
            AdjList[b].Add(a, 0);
        }
        public void addEdjeOr(string a, string b)
        {
            AdjList[a].Add(b, 0);
        }
        public void addEdje(string a, string b, int c )
        {
            AdjList[a].Add(b, c);
            AdjList[b].Add(a, c);
        }
        public void addEdjeOr(string a, string b, int c)
        {
            AdjList[a].Add(b, c);
        }

        public void deleteEdjeOr(string a, string b)
        {
            AdjList[a].Remove(b);
        }
        public void deleteEdje(string a, string b)
        {
            AdjList[a].Remove(b);
            AdjList[b].Remove(a);
        }
        public Dictionary<string, Dictionary<string, int>> GetAdjList
        {
            get
            {
                return AdjList;
            }
        }
        public bool GetWeight
        {
            get
            {
                return Weight;
            }
        }
        public bool GetOrientation
        {
            get
            {
                return Orientation;
            }
        }
        public int GetAmount
        {
            get
            {
                return amount;
            }
        }





        private List<string> rez = new List<string>();
        Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();

        public void Ia_3()
        {
            if (Orientation == false)
            {                
                foreach (string firstKey in AdjList.Keys)
                {
                    System.Console.WriteLine($"{firstKey}: {AdjList[firstKey].Count}");
                }
                System.Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine("Oriented graph");
            }
        }
        public void Ia_16(string a, string b)
        {
            int o = 0;
            foreach (var i in AdjList.Keys)
                if (i == a || i == b)
                    o++;
            if (o!=2)
            {
                global::System.Console.WriteLine("Vertex isn't exist");
                return;
            }

            foreach (var p in AdjList)
            {
                bool aFlag = false, bFlag = false;
                foreach (var node in p.Value)
                {
                    if (node.Key == a)
                        aFlag = true;
                    else if (node.Key == b)
                        bFlag = true;

                    if (aFlag && bFlag)
                    {
                        global::System.Console.WriteLine(p.Key);
                        return;
                    }
                }
                
            }
            global::System.Console.WriteLine("CommonVertex isn't found");

        }

        public void Ib_8_help(Graph b, Graph c, string i)
        {
            foreach (var m in b.AdjList[i].Keys)
            {
                if (rez.Find(h => h.Contains(m)) != null)
                {
                    c.addEdjeOr(i, m);                   
                }
                else
                {
                    c.addNode(m);
                    rez.Add(m);
                    c.addEdjeOr(i, m);
                }
            }
        }
        public void Ib_8(Graph a, Graph b)
        {
            Graph c = new Graph(a);
            bool exist;           
            rez.Clear();
            foreach (var i in a.AdjList.Keys)
                rez.Add(i);

            foreach (var i in b.AdjList.Keys)
            {
                exist = false;
                foreach (var j in rez)
                {
                    if (j == i)
                    {
                        exist = true;
                        Ib_8_help(b, c, i);                                                
                    }
                }
                if (exist == false)
                {
                    c.addNode(i);
                    rez.Add(i);
                    Ib_8_help(b, c, i);
                }
            }
            foreach (var i in c.AdjList.Keys)
            {
                System.Console.Write($"{i}: ");
                foreach (var j in c.AdjList[i])
                {
                    System.Console.Write($"{j.Key}, ");
                }
                System.Console.WriteLine();
            }
        }

        

        private void II_6_help(string s)
        {
            foreach (var i in AdjList.Keys)
            {
                if (i == s)
                {
                    System.Console.WriteLine(s);
                    rez.Remove(s);

                    foreach(var n in AdjList[i].Keys) {                        
                        II_6_help(n);                        
                    }
                    break;
                }
            }
        }

        public void II_6()
        {
            rez.Clear();
            foreach (var i in AdjList.Keys)            
            {
                rez.Add(i);
            }

            while (rez.Count != 0)
            {
                System.Console.WriteLine("New");
                II_6_help(rez[0]);
            }                             

        }       

        
        private void III_help(string a)
        {
            string s = a;
            int min = 100000; // Минимальная длина
            string minName = ""; // Минимальная вершина
            string fromName = ""; // Из вершины         
           
            
            foreach (var i in result.Keys)
            {
                foreach (var j in AdjList[i]) 
                {
                   
                    if ((min > j.Value) && (rez.Find(i=>i.Contains(j.Key))!=null))
                    {
                        min = j.Value;
                        minName = j.Key;
                        fromName = i;
                    }
                }

            }// Поиск минимальной вершины и расстояния до нее
            
            rez.Remove(minName);
            int count = 0;

           
                    result[fromName].Add(minName, min);
                    result.Add(minName, new Dictionary<string, int>());
              

        }
        public void III(string a)
        {            
            rez.Clear();
            foreach (var i in AdjList.Keys) // Список всех вершин
                rez.Add(i);
            result.Add(a, new Dictionary<string, int>());
            rez.Remove(a);
            while (rez.Count != 0)
            {
                III_help(rez[0]);
            }
            
            foreach (var i in result.Keys)
            {
                System.Console.Write($"{i}: ");
                foreach (var j in result[i])
                {
                    System.Console.Write($"{j.Key}-{j.Value}, ");
                }
                System.Console.WriteLine();
            }
               
            }        
        

        
    }
}
