using System.Xml.Linq;

namespace day7
{
    public class day7Challenge
    {
        public void Run()
        {
            using var sr = new StreamReader("input.txt");
            var queue = new Queue<string[]>();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Split(" ");
                if (line.Length == 3)
                {
                    if (line[0].All(char.IsDigit))
                    {
                        dict.Add(line[2], int.Parse(line[0]));
                    }
                    else
                    {
                        queue.Enqueue(line);
                    }

                }
                else
                {
                    queue.Enqueue(line);
                }
            }

            dict = matchAndDecode(queue, dict);



            //if r or l shift => can calculate
            // check dict again
            // new small queue


            dict = DecodeStack(queue);

            dict.TryGetValue("a", out int value);
            Console.WriteLine("This is the value of a: " + value);
        }

        private Dictionary<string, int> matchAndDecode(Queue<string[]> queue, Dictionary<string, int> dict)
        {
            var smallQueue = new Queue<string[]>();
            IEnumerable<string[]> matches = new List<string[]>();
            // find all occurances of values in dict: 
            foreach (KeyValuePair<string, int> entry in dict)
            {
                matches = queue.Where(c => c.Any(d => d.Equals(entry.Key)));
                foreach (var m in matches)
                {
                    //try dict
                    (var failed, dict) = DecodeElement(m, dict);
                    //if (failed)
                    //{
                    //    queue.Enqueue(m);
                    //}
                    //smallQueue.Enqueue(m);
                }
            }

            return dict;
        }

        private Dictionary<string, int> DecodeStack(Queue<string[]> queue)
        {
            var decodedSignalsDict = new Dictionary<string, int>();            
            while(queue.Count != 0)
            {
                var element = queue.Dequeue();
                (var failed, decodedSignalsDict) = DecodeElement(element, decodedSignalsDict);               

                if (failed)
                {
                    queue.Enqueue(element);
                }
            }
            return decodedSignalsDict;
        }

        private (bool, Dictionary<string, int>) DecodeElement(string[] instruction, Dictionary<string, int> dict)
        {
            bool failed = false;
            int value1;
            int value2;
            if(instruction.Length == 4)
            {
                // This is a NOT    
                if (dict.TryGetValue(instruction[1], out value1))
                {
                    var outValue = ~value1;
                    dict.Add(instruction[3], outValue);
                }
                else
                {
                    failed = true;
                }                           
            }
            if (instruction.Contains("AND"))
            {
                if (dict.TryGetValue(instruction[0], out value1))
                {
                    if(dict.TryGetValue(instruction[2], out value2))
                    {
                        var outValue = value1 & value2;
                        dict.Add(instruction[4], outValue);
                    }
                }
                else
                {
                    failed = true;
                }
            }
            else if (instruction.Contains("OR"))
            {
                if (dict.TryGetValue(instruction[0], out value1))
                {
                    if (dict.TryGetValue(instruction[2], out value2))
                    {
                        var outValue = value1 | value2;
                        dict.Add(instruction[4], outValue);
                    }
                }
                else
                {
                    failed = true;
                }
            }
            else if (instruction.Contains("LSHIFT"))
            {
                if (dict.TryGetValue(instruction[0], out value1))
                {
                    var outValue = value1 << int.Parse(instruction[2]);
                    dict.Add(instruction[4], outValue);
                }
                else
                {
                    failed = true;
                }
            }

            else if (instruction.Contains("RSHIFT"))
            {
                if (dict.TryGetValue(instruction[0], out value1))
                {
                    var outValue = value1 >> int.Parse(instruction[2]);
                    dict.Add(instruction[4], outValue);
                }
                else
                {
                    failed = true;
                }
            }
            return (failed, dict);
        }
    }
}
