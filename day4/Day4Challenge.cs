namespace day4
{
    public class Day4Challenge
    {
        public void Main()
        {
            var input = "bgvyzdsv";
            var numberToFind = 0;
            var output = "";
            while (!output.StartsWith("000000"))
            {
                output = CreateMD5(input + numberToFind);
                numberToFind++;
            }
            Console.WriteLine(numberToFind - 1);
            Console.WriteLine(output);
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);
            
            return Convert.ToHexString(hashBytes);
        }
    }
}
