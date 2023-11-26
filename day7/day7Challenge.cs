namespace day7
{
    public class day7Challenge
    {
        public void Run()
        {
            Console.WriteLine("hello");
            using var sr = new StreamReader("input.txt");

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
            }

        }
    }
}
