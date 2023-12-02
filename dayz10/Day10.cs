using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dayz10
{
    public class Day10
    {
        public void Run()
        {
            var input = "1321131112";
            var iterations = 50;

            while (iterations > 0)
            {
                iterations--;
                input = LookAndSay(input);
                

            }
            Console.WriteLine(input.Length);
        }

        private string LookAndSay(string input)
        {
            var pattern = new Regex("1+|2+|3+");
            input = pattern.Replace(input, new MatchEvaluator(Evaluator));

            return input;
        }

        private static string Evaluator(Match m)
        {
            return $"{m.Length}{m.Value[0]}";
        }
    }
}
