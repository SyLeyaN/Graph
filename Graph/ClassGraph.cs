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
            using (StreamReader fileIn = new StreamReader($"C:/Users/SyLeyaN/source/repos/ConsoleApp1/ConsoleApp1/Graph/{file}"))
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
            using (StreamWriter fileOut = new StreamWriter($"E:/Код/Graph/Graph/Graphs/Save/{file}"))
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
        public void Ia()
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
    }
}
