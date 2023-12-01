using System.Text.RegularExpressions;

namespace day8
{
    public class Day8Challenge
    {
        public void Run()
        {
            using var sr = new StreamReader("input.txt");
            var stringCount = StringCount(sr);

            using var sr2 = new StreamReader("input.txt");
            var allCharCount = AllCharacterCount(sr2);

            Console.WriteLine(allCharCount - stringCount);
        }
        public int StringCount(StreamReader sr)
        {            
            var numberOfCharacters = 0;
            
            while (!sr.EndOfStream)
            {
                var currentCount = 0;
                var input = sr.ReadLine();
                var originalInput = input;

                const string innerQuote = @"\\" + "\"";
                const string hexPattern = @"\\x[a-z0-9][a-z0-9]";
                const string firstQuote = "^\"";
                const string lastQuote = "\"$";
                const string backslash = @"\\";                

                input = Regex.Replace(input, firstQuote, "");
                input = Regex.Replace(input, lastQuote, "");
                input = Regex.Replace(input, innerQuote, "1");  
                input = Regex.Replace(input, hexPattern, "1");
                input = input.Replace(backslash, "1");

                currentCount = input.Count(c =>
                !char.IsWhiteSpace(c));

                numberOfCharacters += input.Count(c =>
                !char.IsWhiteSpace(c));
            }
            return numberOfCharacters;
        }

        public int AllCharacterCount(StreamReader sr)
        {
            
            var input = sr.ReadToEnd();
            var numberOfCharacters = input.
                   Count(c =>
                    !char.IsWhiteSpace(c));

            return numberOfCharacters;
        }

        public void Main()
        {
            var lines = File.ReadLines(@"input.txt");

            int totalCode = lines.Sum(l => l.Length);
            int totalCharacters = lines.Sum(CharacterCount);
            int totalEncoded = lines.Sum(EncodedStringCount);

            Console.WriteLine(totalCode - totalCharacters);
            Console.WriteLine(totalEncoded - totalCode);
        }

        int CharacterCount(string arg) => Regex.Match(arg, @"^""(\\x..|\\.|.)*""$").Groups[1].Captures.Count;
        int EncodedStringCount(string arg) => 2 + arg.Sum(CharsToEncode);
        int CharsToEncode(char c) => c == '\\' || c == '\"' ? 2 : 1;
    }
}
