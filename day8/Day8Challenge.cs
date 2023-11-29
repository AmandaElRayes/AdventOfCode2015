namespace day8
{
    public class Day8Challenge
    {
        public void Run()
        {
            using var sr = new StreamReader("input.txt");
            var allCharCount = 0;
            var stringCount = 0;
            //var input = sr.ReadToEnd();

            //allCharCount = AllCharacterCount(input);
            //stringCount = StringCount(input.ToString());

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                allCharCount += AllCharacterCount(line);
                stringCount += StringCount(line.ToString());
            }


            Console.WriteLine(allCharCount - stringCount);
        }

        public int StringCount(string input)
        {
            return input.Length;
        }

        public int AllCharacterCount(string input)
        {
            var numberOfCharacters = input.
                   Count(c =>
                   !char.IsControl(c) &&
                    !char.IsWhiteSpace(c));

            return numberOfCharacters;
        }
    }
}
