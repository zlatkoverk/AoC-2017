using System;
using System.IO;

namespace Main
{
    public class Day15
    {
        public static int GetFirstResult(string input)
        {
            StringReader reader = new StringReader(input);
            long a = int.Parse(reader.ReadLine().Split(' ')[4]);
            long b = int.Parse(reader.ReadLine().Split(' ')[4]);

            int result = 0;
            for (int i = 0; i < 40000000; i++)
            {
                a *= 16807;
                b *= 48271;
                a %= 2147483647;
                b %= 2147483647;

                result += ((a & 0b11111111_11111111) == (b & 0b11111111_11111111) ? 1 : 0);
            }

            return result;
        }

        public static int GetSecondResult(string input)
        {
            StringReader reader = new StringReader(input);
            long a = int.Parse(reader.ReadLine().Split(' ')[4]);
            long b = int.Parse(reader.ReadLine().Split(' ')[4]);

            int result = 0;
            for (int i = 0; i < 5000000; i++)
            {
                do
                {
                    a *= 16807;
                    a %= 2147483647;
                } while (a % 4 != 0);
                do
                {
                    b *= 48271;
                    b %= 2147483647;
                } while (b % 8 != 0);

                result += ((a & 0b11111111_11111111) == (b & 0b11111111_11111111) ? 1 : 0);
            }

            return result;
        }
    }
}