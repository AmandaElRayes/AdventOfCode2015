using System.Text.RegularExpressions;

namespace dayz11
{
    public class Day11
    {
        public void Run()
        {
            var input = "vzbxkghb";
            input = FirstCheck(input);

            Console.WriteLine(input);
        }

        public string FirstCheck(string input)
        {
            bool req2 = CheckReq2(input);
            while (!req2)
            {
                input = Increment(input.ToCharArray(), 7);
                req2 = CheckReq2(input);
            };

            return GetNewPassword(input);
        }

        public string GetNewPassword(string input)
        {
            (bool req1, bool req3) = CheckReq1_3(input);

            if (req1 && req3)
            {
                return input;
            }
            var newPw = Increment(input.ToCharArray(), 7);
            return GetNewPassword(newPw);           
            
        }

        public string Increment(char[] input, int index)
        {
            var lastLetter = input[index];
            if (lastLetter == 'z')
            {
                input[index] = 'a';
                index--;
                Increment(input, index);
            }else if (lastLetter == 'h' | lastLetter == 'n' | lastLetter == 'k'  )
            {
                input[index] = (char)(((int)input[index]) + 2);
            }
            else
            {
                input[index] = (char)(((int)input[index]) + 1);
            }
            return new string(input);
        }

        public (bool, bool) CheckReq1_3(string input)
        {
            bool req1 = CheckReq1(input);
            bool req3 = CheckReq3(input);
            return (req1, req3);
        }

        public bool CheckReq1(string input)
        {
            /*Passwords must include one increasing straight of at least three letters,
            * like abc, bcd, cde, and so on, up to xyz.
            * They cannot skip letters; abd doesn't count.*/
            var charArray = input.ToCharArray();
            var count = 0;
            for (int i = 0; i < charArray.Length - 1 ; i++)
            {
                var firstChar = charArray[i] + 1;
                var secondChar = charArray[i + 1] + 0;
                if (firstChar == secondChar)
                {
                    count++;
                    if(count == 2)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            return false;
        }

        public bool CheckReq2(string input)
        {
            /* Passwords may not contain the letters i, o, or l, 
             * as these letters can be mistaken for other characters and are therefore confusing.
             */
            return !Regex.IsMatch(input, "(i|o|l)");
        }

        public bool CheckReq3(string input)
        {
            /*Passwords must contain at least two different, non-overlapping pairs of letters,
             * like aa, bb, or zz.*/
            //REGEX: . = any character, \1 = matches the same text as most recently matched by the 1st capturing group

            return Regex.Matches(input, "(.)\\1").Count >= 2;
        }

  
    }
}
