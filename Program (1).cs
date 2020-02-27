using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2_CT_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Question 7");
            int rodLength = 4;

            GoldRod(rodLength);

        }

        private static int denom = -1;
        private static List<Tuple<int, string>> result = new List<Tuple<int, string>>();

        public static int GoldRod(int n)
        {
            try
            {
                if (denom == 0)
                {
                    var output = result.OrderByDescending(x => x.Item1).FirstOrDefault();
                    if (output != null)
                    {
                        Console.WriteLine(output.Item2);
                        return 0;
                    }
                }

                if (denom == -1)
                    denom = (int)Math.Floor(n / 2.0);

                if (n % denom == 0)
                {
                    var pow = n / denom;
                    var output = Output(denom, pow);
                    result.Add(output);
                }

                denom--;
                GoldRod(n);
            }
            catch(Exception)
            {
                throw;
            }
            return 0;
        }

        public static Tuple<int, string> Output(int denom, int pow)
        {
            var total = 1;
            var sb = new StringBuilder();
            for (int i = 1; i <= pow; i++)
            {
                sb.Append(denom);

                if (i != pow)
                    sb.Append("*");

                total *= denom;
            }

            sb.Append($"= {total}");

            return new Tuple<int, string>(total, sb.ToString());
        }
    }
}