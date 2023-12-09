namespace dayzz23
{
    public class Day23
    {
        public void Run()
        {
            using StreamReader sr = new("input.txt");
            var row = 1;
            var dict = new Dictionary<int, ManualEntry>();
            while (!sr.EndOfStream)
            {
                var entry = new ManualEntry();
                var line = sr.ReadLine().Split();
                entry.Instruction = line[0];
                switch (entry.Instruction)
                {
                    case "jmp":
                        entry.NoOfJumps = int.Parse(line[1]);
                        break;
                    case "jio": case "jie":
                        entry.Register = line[1];
                        entry.NoOfJumps = int.Parse(line[2]);
                        break;
                    default:
                        entry.Register = line[1];
                        break;
                }
                dict.Add(row, entry);
                row++;
                
            }

            int a = 0, b = 0;
            int currentRow = 1;
            while (true)
            {
                if (currentRow < 1 || currentRow > dict.Count)
                {
                    Exit(a, b);
                }
                dict.TryGetValue(currentRow, out var entry);
                //Console.WriteLine($"Current row: {currentRow}; Instruction = {entry.Instruction};  a = {a}; b = {b}");
   
                switch (entry.Instruction)
                {
                    case "hlf":
                        switch (entry.Register.StartsWith('a'))
                        {
                            case true:
                                a /= 2;
                                break;
                            case false:
                                b /= 2;
                                break;
                        }
                        currentRow++;
                        break;
                    case "tpl":
                        switch (entry.Register.StartsWith('a'))
                        {
                            case true:
                                a *= 3;
                                break;
                            case false:
                                b *= 3;
                                break;
                        }
                        currentRow++;
                        break;
                    case "inc":
                        switch (entry.Register.StartsWith('a'))
                        {
                            case true:
                                a += 1;
                                break;
                            case false:
                                b += 1;
                                break;
                        }
                        currentRow++;
                        break;
                    case "jmp":
                        currentRow += entry.NoOfJumps;
                        break;
                    case "jie":
                        switch (entry.Register.StartsWith('a'))
                        {
                            case true:
                                if(a % 2 == 0)
                                {
                                    currentRow += entry.NoOfJumps;
                                }
                                else
                                {
                                    currentRow++;
                                }
                                break;
                            case false:
                                if (b % 2 == 0)
                                {
                                    currentRow += entry.NoOfJumps;
                                }
                                else
                                {
                                    currentRow++;
                                }
                                break;
                        }
                        break;
                    case "jio": // jump if one
                        switch (entry.Register.StartsWith('a'))
                        {
                            case true:
                                if (a == 1)
                                {
                                    currentRow += entry.NoOfJumps;
                                }
                                else
                                {
                                    currentRow++;

                                }
                                break;
                            case false:
                                if (b == 1)
                                {
                                    currentRow += entry.NoOfJumps;

                                }
                                else
                                {
                                    currentRow++;
                                }
                                break;
                        }
                        break;
                }
            }

        }

        private static void Exit(double a, double b)
        {
            Console.WriteLine($"a = {a}, b = {b}");
            Environment.Exit(0);
        }
    }

    public class ManualEntry
    {
        public string Instruction { get; set; }
        public string Register { get; set; }
        public int NoOfJumps { get; set; }
    }
}
