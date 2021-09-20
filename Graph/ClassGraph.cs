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
    }
}
