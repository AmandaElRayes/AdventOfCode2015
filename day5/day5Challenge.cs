using System.Diagnostics;
using System.Text.RegularExpressions;

namespace day5
{
    public class Day5Challenge
    {
        public void Run()
        {
            using var sr = new StreamReader("input.txt");
            var niceCount = 0;
            //var line;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                //Validate(ref niceCount, line);
                Part2Validation(ref niceCount, line);
            }

            Console.WriteLine(niceCount);
        }

        private void Part2Validation(ref int niceCount, string line)
        {
            bool isValid = ValidateRule1P2(line);
            if (isValid)
            {
                isValid = ValidateRule2P2(line);
                if (isValid)
                {
                    niceCount++;
                }
            }
        }

        private bool ValidateRule1P2(string line)
        {
            //It contains a pair of any two letters that appears at least twice in the string without overlapping,
            //like xyxy(xy) or aabcdefgaa(aa), but not like aaa(aa, but it overlaps).
            string pattern = @"(?=([a-zA-Z]{2}).*\1)";
            return Regex.IsMatch(line, pattern);
        }

        private bool ValidateRule2P2(string line)
        {
            //It contains at least one letter which repeats with exactly one letter between them,
            //like xyx, abcdefeghi(efe), or even aaa.
            string pattern = @"([a-zA-Z])\w\1";
            return Regex.IsMatch(line, pattern);
        }



        public void Validate(ref int niceCount, string line)
        {
            bool isValid = ValidateVowels(line);
            if (isValid)
            {
                isValid = ValidateDoubles(line);
                if (isValid)
                {
                    isValid = ValidateForbiddenStrings(line);
                    if (isValid)
                    {
                        niceCount++;
                    }
                }
            }
        }

        private bool ValidateVowels(string line)
        {
            var vowels = new List<string>() { "a", "e", "i", "o", "u"};
            var count = 0;
            foreach (var letter in line)
            {
                if (vowels.Contains(letter.ToString()))
                {
                    count++;
                }
                if (count >= 3)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidateDoubles(string line)
        {
            var charArray = line.ToCharArray();

            for(var i = 1; i<charArray.Length; i++)
            {
                if (charArray[i] == charArray[i - 1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidateForbiddenStrings(string line)
        {
            var forbiddenStrings = new List<string>()
            {
                "ab",
                "cd",
                "pq",
                "xy"
            };

            foreach (var forbiddenString in forbiddenStrings)
            {
                if (line.Contains(forbiddenString))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
