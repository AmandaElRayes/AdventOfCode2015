namespace day7
{
    public class day7Challenge
    {
        public void BruteForce()
        {
            using var sr = new StreamReader("input.txt");
            var queue = new List<string[]>();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            while (!sr.EndOfStream)
            {
                queue.Add(sr.ReadLine().Split(" "));
            }

            var signal = "a";
            RecursiveMethod(queue, ref dict, signal);
            Console.WriteLine("done");

        }

        private object RecursiveMethod(List<string[]> queue, ref Dictionary<string, int> dict, string signalToCheck)
        {
            if (dict.TryGetValue("a", out int valueFound))
            {
                Console.WriteLine("a = " + valueFound);
                return null;
            }
            var element = queue.Where(x => x.Last() == signalToCheck).First();

            (var failedLetter, dict) = DecodeElement(element, dict);


            if (failedLetter != string.Empty)
            {
                var signalsToCheck = failedLetter.Split(" ");
                RecursiveMethod(queue, ref dict, signalsToCheck[0]);
                if (signalsToCheck.ElementAtOrDefault(1) != null)
                {
                    RecursiveMethod(queue, ref dict, signalsToCheck[1]);
                }
            }
            else
            {
                // start going back up
                RecursiveMethod(queue, ref dict, "a");
            }
            return null;

        }

        public (string, Dictionary<string, int>) DecodeElement(string[] instruction, Dictionary<string, int> dict)
        {
            string failedLetters = string.Empty;
            if (instruction.Length == 3)
            {
                if (instruction[0].All(char.IsDigit))
                {
                    failedLetters = Equal(instruction, dict);
                }
                else
                {
                    failedLetters = instruction[0];
                }

            }
            if (instruction.Length == 4)
            {
                failedLetters = NOT(instruction, dict);
            }
            if (instruction.Contains("AND"))
            {
                failedLetters = AND(instruction, dict);
            }
            if (instruction.Contains("OR"))
            {
                failedLetters = OR(instruction, dict);
            }
            if (instruction.Contains("LSHIFT"))
            {
                failedLetters = LSHIFT(instruction, dict);
            }
            if (instruction.Contains("RSHIFT"))
            {
                failedLetters = RSHIFT(instruction, dict);
            }
            return (failedLetters, dict);
        }

        private static string Equal(string[] instruction, Dictionary<string, int> dict)
        {
            var success = dict.TryAdd(instruction[2], int.Parse(instruction[0]));
            Console.WriteLine($"{instruction[2]} = {int.Parse(instruction[0])} EQUAL");
            if (!success)
            {
                return instruction[2];
            }

            return string.Empty;
        }

        private static string NOT(string[] instruction, Dictionary<string, int> dict)
        {
            int value1;
            if (instruction[1].All(char.IsDigit))
            {
                value1 = int.Parse(instruction[1]);
            }
            else
            {
                var success = dict.TryGetValue(instruction[1], out value1);
                if (!success)
                {
                    return instruction[1];
                }
            }
            var outValue = ~value1;
            dict.TryAdd(instruction[3], outValue);
            Console.WriteLine($"{instruction[3]} = {outValue} NOT");


            return string.Empty;
        }
        private static string AND(string[] instruction, Dictionary<string, int> dict)
        {
            int value1;
            int value2;
            if (instruction[0].All(char.IsDigit))
            {
                value1 = int.Parse(instruction[0]);
            }
            else
            {
                var success = dict.TryGetValue(instruction[0], out value1);
                if (!success)
                {
                    return instruction[0] + " " + instruction[2];
                }
            }
            if (instruction[2].All(char.IsDigit))
            {
                value2 = int.Parse(instruction[2]);
            }
            else
            {
                var success = dict.TryGetValue(instruction[2], out value2);
                if (!success)
                {
                    return instruction[2];
                }
            }

            var outValue = value1 & value2;
            dict.TryAdd(instruction[4], outValue);
            Console.WriteLine($"{instruction[4]} = {outValue} AND");


            return string.Empty;
        }

        private static string OR(string[] instruction, Dictionary<string, int> dict)
        {
            int value1;
            int value2;
            if (instruction[0].All(char.IsDigit))
            {
                value1 = int.Parse(instruction[0]);
            }
            else
            {
                var success = dict.TryGetValue(instruction[0], out value1);
                if (!success)
                {
                    return instruction[0] + " " + instruction[2];
                }
            }
            if (instruction[2].All(char.IsDigit))
            {
                value2 = int.Parse(instruction[2]);
            }
            else
            {
                var success = dict.TryGetValue(instruction[2], out value2);
                if (!success)
                {
                    return instruction[2];
                }
            }

            var outValue = value1 | value2;
            dict.TryAdd(instruction[4], outValue);
            Console.WriteLine($"{instruction[4]} = {outValue} OR");

            return string.Empty;
        }

        private static string LSHIFT(string[] instruction, Dictionary<string, int> dict)
        {
            int value1;
            if (instruction[0].All(char.IsDigit))
            {
                value1 = int.Parse(instruction[0]);
            }
            else
            {
                var success = dict.TryGetValue(instruction[0], out value1);
                if (!success)
                {
                    return instruction[0];
                }
            }

            var outValue = value1 << int.Parse(instruction[2]);
            dict.TryAdd(instruction[4], outValue);
            Console.WriteLine($"{instruction[4]} = {outValue} LSHIFT");


            return string.Empty;
        }

        private static string RSHIFT(string[] instruction, Dictionary<string, int> dict)
        {
            int value1;
            if (instruction[0].All(char.IsDigit))
            {
                value1 = int.Parse(instruction[0]);
            }
            else
            {
                var success = dict.TryGetValue(instruction[0], out value1);
                if (!success)
                {
                    return instruction[0];
                }
            }

            var outValue = value1 >> int.Parse(instruction[2]);
            dict.TryAdd(instruction[4], outValue);
            Console.WriteLine($"{instruction[4]} = {outValue} RHIFT");

            return string.Empty;
        }
    }
}
