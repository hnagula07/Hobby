using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaToNum
{
    class Program
    {
        static void Main(string[] args)
        {
            char loop = 'Y';
            while (loop == 'Y')
            {
                Console.WriteLine("Enter AN(AlphaToNumeric) or NA(NumericToAlpha)");
                try
                {
                    string check = Console.ReadLine().ToUpper();
                    if (check.Equals("AN"))
                        Console.WriteLine(GetNum());

                    else if (check.Equals("NA"))
                        Console.WriteLine(GetAlp());

                    else
                        Console.WriteLine("enter AN or NA");
                }
                catch { Console.WriteLine("check your inputs"); }

                Console.WriteLine("Press 'Y' to continue");
                loop = Convert.ToChar(Console.ReadLine().ToUpper());
            }
        }

        private static string GetNum()
        {
            Console.WriteLine("Enter Alphabet upto length 2");
            string let = Console.ReadLine().ToUpper();
            if (let.Length > 2)
                return "Length Should not be exceeded 2Char";

            int oneLetter = let[0] - 64;

            if (let.Length == 2)
                return (oneLetter * 26 + (let[1] - 64)).ToString();

            return oneLetter.ToString();

        }

        private static string GetAlp()
        {
            Console.WriteLine("Enter number");
            string result = string.Empty;
            try
            {
                int v = Convert.ToInt32(Console.ReadLine());
                int mod = v % 26;
                if (v <= 26)
                    result = Convert.ToChar(64 + v).ToString();
                else if (mod > 1)
                {
                    char a = Convert.ToChar(mod + 64);
                    char b = Convert.ToChar(v/26 + 64);
                    result = Convert.ToString(b) + Convert.ToString(a);
                }
                return result;
            }
            catch { return "Enter valid number"; };
        }
    }
}
