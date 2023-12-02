using System.Collections.Generic;

namespace day9
{
    public class Day9
    {
        public void Run()
        {
            using var sr = new StreamReader("input.txt");
            Dictionary<int, string[]> dict = new();
            int shortestDistance = 0;
            var parentName = string.Empty;
            Node root = new(0, "0"); // first root is empty
            var childrenList = new List<Node>();
            var index = 0;
            var input = sr.ReadToEnd().Split("\r\n");

            root = BuildTree(ref parentName, ref childrenList, root, input, index);

            shortestDistance = GetShortestDistance(root, ref shortestDistance);

            Console.WriteLine(shortestDistance);
        }

        private static int GetShortestDistance(Node root, ref int shortestDistance)
        {
            shortestDistance += root.Distance;
            var smallestChild = root.GetSmallestChild(root.Children);
            if (smallestChild.HasChildren())
            {
                GetShortestDistance(smallestChild, ref shortestDistance);
            }
            else
            {
                shortestDistance += smallestChild.Distance;
            }
            return shortestDistance;
        }

        private static Node BuildTree(ref string parentName, ref List<Node> childrenList, Node root, string[] input, int index)
        {
            string[] line;
            if(index < input.Length)
            {
                line = input[index].Split(" ") ?? throw new ArgumentNullException();
            }
            else
            {
                return root;
            }
            
            if (string.IsNullOrEmpty(parentName))
            {
                parentName = line[0];
                root = new Node(int.Parse(line[4]), line[0]);
            }
            else
            {
                if (parentName == line[0])
                {
                    // add to list
                    childrenList.Add(new Node(int.Parse(line[4]), line[2]));
                }
                else
                {
                    
                    childrenList.Add(new Node(int.Parse(line[4]), line[0]));
                    root.AddChild(childrenList, parentName);

                    childrenList = new List<Node>();

                }
                parentName = line[0];

            }
            
            if (root.HasChildren())
            {
                index++;
                //for (var i = root.Children.Count()-1; i >= 0; i--)
                //{
                //    var newroot = root?.Children?.Where(x => x.Name == line[0]).First();
                //    if (newroot != null)
                //    {
                //        BuildTree(ref parentName, ref childrenList, newroot, input, index);
                //    }
                //    else
                //    {
                //        i--;
                //    }
                //}               
                for (var i = root.Children.Count() - 1; i >= 0; i--)
                {
                    var newroot = root?.Children?.Where(x => x.Name == root.Children[i].Name).First();
                    parentName = root.Children[i].Name;
                    if (newroot != null)
                    {
                        BuildTree(ref parentName, ref childrenList, newroot, input, index);
                    }
                }

            }
            else
            {
                index++;

            }
            return BuildTree(ref parentName, ref childrenList, root, input, index);
        }

        private static void AddToDictionary(Dictionary<int, string[]> dict, string[] line)
        {
            var distance = int.Parse(line[4]);
            var cities = new string[] { line[0], line[2] };
            dict.Add(distance, cities);
        }
    }

    public class Node
    {
        public int Distance { get; set; }
        public string Name { get; set; }
        public List<Node>? Children { get; set; }

        public Node(int id, string name)
        {
            this.Distance = id;
            this.Name = name;
        }

        public bool HasChildren()
        {
            if(this.Children != null)
            {
                return true;
            }
            return false;
        }

        public List<Node> AddChild(List<Node> nodes, string name)
        {
            if(this.Children == null)
            {
                this.Children = new List<Node>();
                foreach(Node node in nodes)
                {
                    this.Children.Add(node);
                }
            }

            return this.Children;
        }

        public Node GetSmallestChild(List<Node> nodes)
        {
            Node smallestNode = new Node(0, "0");
            for (int i = 0; i < nodes.Count() - 1; i++)
            {
                if (nodes[i].Distance >= nodes[i + 1].Distance)
                {
                    smallestNode = nodes[i + 1];
                }
                else
                {
                    smallestNode = nodes[0];
                }
            }
            return smallestNode;
        }
    }

}
