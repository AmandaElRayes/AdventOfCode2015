using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace dayz12
{
    public class Day12
    {
        public void Run()
        {

            using var sr = new StreamReader("input.txt");
            var input = sr.ReadToEnd();            
            //Part1(input);
            Part2(input);
        }

        private static void Part2(string input)
        {
            //var jsonObject = JsonConvert.DeserializeObject(input);
            var jsonObject = JArray.Parse(input);
            var matches = new List<int>();
            var children = jsonObject.Children();
            CheckChildToken(children, ref matches);


            Console.WriteLine("Part 2: " + matches.Sum());
        }

        private static void CheckChildToken(JEnumerable<JToken>? children, ref List<int> matches)
        {            
            foreach (var child in children)
            {
                if(child.Children().Any())
                {
                    CheckChildToken(child.Children(), ref matches);
                }
                Console.WriteLine(child.Values().First());
            }
            Console.WriteLine("sdf");
        }

        private static void Part1(string input)
        {
            var matches = Regex.Matches(input, "\\d+|-\\d+");

            var digits = matches.Select(x => int.Parse(x.Value));

            Console.WriteLine("Part 1: " + digits.Sum());
        }
    }
}
