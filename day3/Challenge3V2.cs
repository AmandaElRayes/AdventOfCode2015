namespace day3
{
    public class Challenge3V2
    {
        public int HousesMain()
        {
            using var sr = new StreamReader("day3input.txt");
            var input = sr.ReadToEnd();
            var santaInput = "";
            var roboSantaInput = "";
            var count = 0;
            foreach (char element in input)
            {
                if (IsEven(count))
                {
                    santaInput += element;
                }
                else
                {
                    roboSantaInput += element;
                }
                count++;

            }
            var santaDict = CreateDictionary(santaInput);
            var roboSantaDict = CreateDictionary(roboSantaInput);

            var distinctEntries = santaDict.Concat(roboSantaDict).Distinct();
            Console.WriteLine("Part two:" + distinctEntries.Count());
            var dictionary = CreateDictionary(input);
            var noOfHouses = dictionary.Count;
            Console.WriteLine("Part one: " + noOfHouses);
            return noOfHouses;
        }

        private static bool IsEven(int count)
        {
            if (count % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public Dictionary<string, int> CreateDictionary(string input)
        {
            var indicesOfHouses = new Dictionary<string, int>();
            var rowIndex = 0;
            var colIndex = 0;
            var index = $"({rowIndex}, {colIndex})";
            indicesOfHouses.Add(index, 1);

            foreach (char element in input)
            {
                switch (element.ToString())
                {
                    case "^":
                        rowIndex--;
                        break;
                    case "<":
                        colIndex--;
                        break;
                    case "v":
                        rowIndex++;
                        break;
                    case ">":
                        colIndex++;
                        break;
                    default:
                        Console.WriteLine("Error: should not end up here.");
                        break;
                }
                indicesOfHouses.TryAdd($"({rowIndex}, {colIndex})", 1);
            }
            return indicesOfHouses;
        }
    }
}
