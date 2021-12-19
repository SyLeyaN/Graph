using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Graphs
{
    public class Graph
    {
        private Dictionary<string, Dictionary<string, int>> AdjList = new Dictionary<string, Dictionary<string, int>>();
        private bool Weight = false;
        private bool Orientation = false;
        private int amount = 0;

        public struct Edje : IComparable<Edje>
        {
            public string start;
            public string end;
            public int weight;
            public int CompareTo(Edje x)
            {
                if (weight < x.weight)
                {
                    return -1;
                }
                if (weight > x.weight)
                {
                    return 1;
                }
                return 0;
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
            using (StreamWriter fileOut = new StreamWriter($"C:/Код/DZ/Graph/Graph/Graphs/Save/{file}"))
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
        public void Ib_8(Graph a, Graph b)
        {
            Graph c = new Graph();
            bool exist;           
            rez.Clear();
            foreach (var i in a.AdjList.Keys)
                rez.Add(i);
            List<string> help = new List<string>();


            foreach (var i in b.AdjList.Keys) //Берем каждый элемент из 1 графа
            {          
                
                foreach (var j in rez)
                {
                    if (j == i)
                    {
                        if (b.AdjList[i].Keys.Count == 0)
                        {
                            help.Add(i);
                            c.addNode(i);
                        }

                        foreach (var m in b.AdjList[i].Keys)
                        {
                            if (rez.Find(h => h.Contains(m)) != null)
                            {
                                
                                if (help.Find(h => h.Contains(m)) == null)                                                                   
                                    c.addNode(m);
                                
                                if(help.Find(h => h.Contains(i)) == null)
                                    c.addNode(i);

                                help.Add(i);
                                help.Add(m);
                                c.addEdjeOr(i, m);                              
                                                                  
                                
                            }
                        }
                    }
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
            result.Add(minName, new Dictionary<string, int>());
            result[fromName].Add(minName, min);
              

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
        public void II_18()
        {
            Dictionary<string, List<string>> tempDict = new Dictionary<string, List<string>>();
            if (!GetOrientation)
            {
                for (int i = 0; i < amount; i++)
                {
                    List<string> tempList = new List<string>();
                    List<string> keys = new List<string>(AdjList.Keys);
                    string temp = keys[i];
                    foreach (string elem in AdjList.Keys)
                    {
                        if (elem == temp)
                        {
                            foreach (string item in AdjList[elem].Keys)
                            {
                                if (!tempList.Contains(item))
                                {
                                    tempList.Add(item);
                                }
                            }
                        }
                        else
                        {
                            if (AdjList[elem].ContainsKey(temp) && !tempList.Contains(elem))
                            {
                                tempList.Add(elem);
                            }
                        }
                    }
                    tempDict.Add(temp, tempList);
                }
            }
            else
            {
                foreach (string key in AdjList.Keys)
                {
                    List<string> tempList = new List<string>();
                    foreach (string elem in AdjList[key].Keys)
                    {
                        tempList.Add(elem);
                    }
                    tempDict.Add(key, tempList);
                }
            }
            System.Console.WriteLine($"isTree");
            foreach (string key in tempDict.Keys)
            {
                System.Console.Write($"{key}:");
                foreach (string elem in tempDict[key])
                {
                    System.Console.Write($"[{elem}]");
                }
                System.Console.WriteLine();
            }
            List<bool> tree = new List<bool>();
            int n = 0;
            List<string> keys1 = new List<string>(tempDict.Keys);
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            foreach (string item in keys1)
            {
                visited.Add(item, false);
            }
            while (visited.ContainsValue(false))
            {
                tree.Add(true);
                List<List<string>> traversals = new List<List<string>>();
                List<List<string>> updtraversals = new List<List<string>>();
                traversals.Add(new List<string>());
                foreach (KeyValuePair<string, bool> item in visited)
                {
                    if (item.Value == false)
                    {
                        traversals[0].Add(item.Key);
                        visited[item.Key] = true;
                        break;
                    }
                }
                int length = 0;
                while (tree[n])
                {
                    length += 1;
                    foreach (List<string> item in traversals)
                    {
                        System.Console.Write("[");
                        foreach (string elem in item)
                        {
                            System.Console.Write($"({elem})");
                        }
                        for (int i = 0; i < item.Count - 1; i++)
                        {
                            for (int j = i + 1; j < item.Count; j++)
                            {
                                if (item[i] == item[j])
                                {
                                    tree[n] = false;
                                }
                            }
                        }
                        string k = item[length - 1].ToString();
                        foreach (string elem in tempDict[k])
                        {

                            if (length == 1 || elem != item[length - 2].ToString())
                            {
                                List<string> temp = new List<string>(item);
                                temp.Add(elem);
                                updtraversals.Add(temp);
                                visited[elem] = true;
                            }
                        }
                        System.Console.Write("]");
                    }
                    System.Console.WriteLine("");
                    if (traversals.Count == 0)
                    {
                        break;
                    }
                    traversals.Clear();
                    traversals.AddRange(updtraversals);
                    updtraversals.Clear();
                }
                n += 1;
            }
            foreach (bool item in tree)
            {
                System.Console.Write($"[{item}]");
            }
            System.Console.WriteLine();
            if (tree.Contains(false))
            {
                System.Console.WriteLine("IsForest:False");
            }
            else
            {
                System.Console.WriteLine("IsForest:True");
            }
        }
        public int V(string start, string end)
        {
            int maxStream = 0;
            List<Edje> edjes = streamEdjes();
            while (true)
            {
                List<string> path = onePath(start, end);
                if (path == null)
                {
                    break;
                }
                int min = minStream(edjes, path);
                maxStream += min;
                UpdateEdjes(edjes, path, min);
                AdjList = new Dictionary<string, Dictionary<string, int>>();
                foreach (Edje e in edjes)
                {
                    if (!AdjList.ContainsKey(e.start))
                    {
                        AdjList[e.start] = new Dictionary<string, int>();
                    }
                    if (!AdjList.ContainsKey(e.end))
                    {
                        AdjList[e.end] = new Dictionary<string, int>();
                    }
                    addEdjeOr(e.start, e.end, e.weight);
                }
            }
            return maxStream;
        }
        private List<Edje> streamEdjes()
        {
            List<Edje> tempArr = new List<Edje>();
            foreach (KeyValuePair<string, Dictionary<string, int>> i in AdjList)
            {
                foreach (KeyValuePair<string, int> j in i.Value)
                {
                    bool need = true;
                    foreach (Edje check in tempArr)
                    {
                        if (check.end == i.Key && check.start == j.Key)
                        {
                            need = false;
                            break;
                        }
                    }

                    if (need)
                    {
                        Edje tempEdje = new Edje();
                        tempEdje.start = i.Key;
                        tempEdje.end = j.Key;
                        tempEdje.weight = j.Value;
                        tempArr.Add(tempEdje);
                    }
                }
            }
            return tempArr;
        }
        public List<string> onePath(string start, string end)
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            foreach (KeyValuePair<string, Dictionary<string, int>> temp in AdjList)
            {
                visited.Add(temp.Key, false);
            }
            List<string> tempArr = new List<string>();
            bool need = true;
            dfs_onePath(visited, start, end, tempArr, ref need);
            if (tempArr.Count() == 0)
            {
                return null;
            }
            return tempArr;
        }
        private void dfs_onePath(Dictionary<string, bool> visited, string v, string x, List<string> temp, ref bool need)
        {
            if (!need)
            {
                return;
            }
            temp.Add(v);
            if (v == x)
            {
                need = false;
                return;
            }
            visited[v] = true;
            foreach (KeyValuePair<string, int> i in AdjList[v])
            {
                if (!visited[i.Key])
                {
                    dfs_onePath(visited, i.Key, x, temp, ref need);
                    if (!need)
                    {
                        break;
                    }
                }
            }
            if (!need)
            {
                return;
            }
            visited[v] = false;
            temp.Remove(v);
        }
        public int minStream(List<Edje> edjes, List<string> path)
        {
            int min = int.MaxValue;
            for (int i = 0; i < path.Count - 1; ++i)
            {
                foreach (Edje t in edjes)
                {
                    if (t.start == path[i] && t.end == path[i + 1] && t.weight < min)
                    {
                        min = t.weight;
                    }
                }
            }
            return min;
        }
        public void UpdateEdjes(List<Edje> edjes, List<string> path, int min)
        {
            for (int i = 0; i < edjes.Count(); ++i)
            {
                for (int j = 0; j < path.Count - 1; ++j)
                {
                    if (edjes[i].start == path[j] && edjes[i].end == path[j + 1])
                    {
                        Edje temp = new Edje();
                        temp.start = edjes[i].start;
                        temp.end = edjes[i].end;
                        temp.weight = edjes[i].weight - min;
                        edjes[i] = temp;
                    }
                }
            }
            edjes.RemoveAll(x => x.weight == 0);
        }





        public void IVc_8(Dictionary<string, Dictionary<string, int>> ar, string u, int n)//Bellman-Ford
        {
            Dictionary<string, bool> nov = new Dictionary<string, bool>();
            foreach (var i in AdjList.Keys)
                nov.Add(i, true);
            int maxWay = int.MaxValue;
            List<Dictionary<string, int>> l = new List<Dictionary<string, int>>();
            foreach (KeyValuePair<string, Dictionary<string, int>> keyValue in ar)
            {
                if (keyValue.Key != u)
                {
                    Dictionary<string, int> help = new Dictionary<string, int>();
                    foreach (KeyValuePair<string, Dictionary<string, int>> keyValue1 in ar)
                    {
                        help.Add(keyValue1.Key, maxWay);
                    }
                    help[keyValue.Key] = 0;
                    Dictionary<string, bool> nov1 = new Dictionary<string, bool>();
                    foreach (KeyValuePair<string, bool> keyValue1 in nov)
                    {
                        nov1.Add(keyValue1.Key, true);
                    }
                    Dictionary<string, int> help0 = IVc_8_help(ar, keyValue.Key, nov1, help);
                    l.Add(help0);
                }
            }

            foreach (var i in l)
            {
                if (i[u] != maxWay && i[u] <= n)
                {
                    foreach (KeyValuePair<string, int> keyValue in i)
                    {
                        if (i[keyValue.Key] == 0)
                            Console.Write("{0} ", keyValue.Key);
                    }
                }
            }
        }

        public Dictionary<string, int> IVc_8_help(Dictionary<string, Dictionary<string, int>> ar,
            string u, Dictionary<string, bool> nov, Dictionary<string, int> help)
        {
            int maxWay = int.MaxValue;
            string minKey = "";
            foreach (var i in ar[u])
            {
                if ((help[i.Key] > i.Value + help[u]) && (nov[i.Key])) { help[i.Key] = i.Value + help[u]; }
            }
            foreach (var i in help)
            {
                if ((i.Value < maxWay) && (nov[i.Key]))
                {
                    maxWay = i.Value;
                    minKey = i.Key;
                }
            }
            nov[u] = false;
            if (maxWay != int.MaxValue)
            {
                IVc_8_help(ar, minKey, nov, help);
            }
            return help;
        }

        

        public string IVb_4(string u, string v1, string v2)
        {
            if (!GetWeight)
            {
                System.Console.WriteLine("Not_Weighted");
                return "Not_Weighted";
            }
            Dictionary<string, Dictionary<string, int>> tempDict1 = new Dictionary<string, Dictionary<string, int>>();
            if (!GetOrientation)
            {
                for (int i = 0; i < amount; i++)
                {
                    Dictionary<string, int> tempDict0 = new Dictionary<string, int>();
                    List<string> keys = new List<string>(AdjList.Keys);
                    string temp = keys[i];
                    foreach (string elem in AdjList.Keys)
                    {
                        if (elem == temp)
                        {
                            foreach (string item in AdjList[elem].Keys)
                            {
                                if (!tempDict0.ContainsKey(item))
                                {
                                    tempDict0.Add(item, AdjList[elem][item]);
                                }
                            }
                        }
                        else
                        {
                            if (AdjList[elem].ContainsKey(temp) && !tempDict0.ContainsKey(elem))
                            {
                                tempDict0.Add(elem, AdjList[elem][temp]);
                            }
                        }
                    }
                    tempDict1.Add(temp, tempDict0);
                }
            }
            else
            {
                foreach (string key in AdjList.Keys)
                {
                    Dictionary<string, int> tempDict0 = new Dictionary<string, int>();
                    foreach (string elem in AdjList[key].Keys)
                    {
                        tempDict0.Add(elem, AdjList[key][elem]);
                    }
                    tempDict1.Add(key, tempDict0);
                }
            }
            //заполняем матрицу смежности
            Dictionary<string, Dictionary<string, int>> tempMatrix = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> tempDict = new Dictionary<string, int>();
            foreach (string key in tempDict1.Keys)
            {
                tempMatrix.Add(key, new Dictionary<string, int>());
                foreach (string key2 in tempDict1.Keys)
                {
                    tempMatrix[key].Add(key2, 2147483647);
                }
                foreach (string key2 in tempDict1[key].Keys)
                {
                    int value = 2147483647;
                    if (tempDict1[key].TryGetValue(key2, out value))
                    {
                        tempMatrix[key][key2] = value;
                    }
                }
            }
            
            foreach (string k in tempMatrix.Keys)
            {
                foreach (string i in tempMatrix[k].Keys)
                {
                    foreach (string j in tempMatrix[k].Keys)
                    {
                        if (tempMatrix[i][k] < 2147483647 && tempMatrix[k][j] < 2147483647)
                        {
                            if (tempMatrix[i][j] > tempMatrix[i][k] + tempMatrix[k][j])
                            {
                                tempMatrix[i][j] = tempMatrix[i][k] + tempMatrix[k][j];
                            }
                        }
                    }
                }
            }
            System.Console.WriteLine($"Длина кратчайшего пути от {u} до {v1} = {tempMatrix[u][v1]}");
            System.Console.WriteLine($"Длина кратчайшего пути от {u} до {v2} = {tempMatrix[u][v2]}");
            return $"v1:{tempMatrix[u][v1]},v2{tempMatrix[u][v2]}";
        }

        
        public Dictionary<string, long> IVa_2(string node)
        {
            rez.Clear();
            Dictionary<string, bool> visit = new Dictionary<string, bool>();

            foreach (var k in AdjList.Keys)
            {
                rez.Add(k);
                visit.Add(k, false);
            }             
            
            
            visit[node] = true;
            var currentNode = AdjList[node];

            foreach (var item in rez)
            {
                if (!currentNode.ContainsKey(item))
                {
                    currentNode.Add(item, Int32.MaxValue);
                }
            }

            Dictionary<string, long> dists = new Dictionary<string, long>();

            for (int i = 0; i < rez.Count; ++i)
            {
                dists.Add(rez[i], currentNode[rez[i]]);
            }

            foreach (var item in currentNode)
            {
                Console.WriteLine($"{item.Key.ToString()} --- {item.Value}");
            }

            foreach (var element in rez)
            {
                long min = Int32.MaxValue;
                string w = rez[0];

                foreach (var nextElement in rez)
                {
                    if (!visit[nextElement] && dists[nextElement] < min)
                    {
                        min = dists[nextElement];
                        w = nextElement;
                    }
                }

                visit[w] = true;

                foreach (var nextElement in rez)
                {
                    long dist = dists[w] + this[w, nextElement];

                    if (!visit[nextElement] && dist < dists[nextElement])
                    {
                        dists[nextElement] = dist;
                    }
                }
            }

            return dists;
        }
        public int this[string from, string to]
        {
            get
            {
                if (AdjList[from].ContainsKey(to))
                {
                    return AdjList[from][to];
                }
                else
                {
                    return Int32.MaxValue;
                }
            }
            set
            {
                AdjList[from][to] = value;
            }
        }


    }
}
