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
            // cities, distance between
            while (!sr.EndOfStream)
            {
                var line = sr?.ReadLine()?.Split(" ") ?? throw new ArgumentNullException();

                root = BuildTree(ref parentName, ref childrenList, root, line);
                AddToDictionary(dict, line);
            }

            // create a map/tree for each place
            Console.WriteLine(shortestDistance);
        }

        private static Node BuildTree(ref string parentName, ref List<Node> childrenList, Node root, string[] line)
        {

            
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
                    var children = root.AddChild(childrenList, parentName);

                    childrenList = new List<Node>();

                }

            }
            parentName = line[0];
            if (root.HasChildren(root))
            {
                var newNode = root.Children.Where(x => x.Name == line[0]).First();
                BuildTree(ref parentName, ref childrenList, newNode, line);
            }
            
            return root;
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

        public bool HasChildren(Node node)
        {
            if(node.Children != null)
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
            else
            {
                // should not end up here we already have a list of nodes
                var x = this.Children.Where(x => x.Name == name).First();
                this.Children.Add(x);  
                foreach (var node in nodes)
                {
                    this.Children.Add(node);
                }
            }

            return this.Children;
        }
    }

}
