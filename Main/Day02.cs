using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Main
{
    public class Day02
    {
        public static int GetFirstResult(String input)
        {
            StringReader reader = new StringReader(input);
            int checksum = 0;

            while (reader.Peek() > -1)
            {
                string[] numStrings = reader.ReadLine().Split('\t');
                checksum += GetDif(numStrings);
            }

            return checksum;
        }

        private static int GetDif(string[] numStrings)
        {
            int min = int.Parse(numStrings[0]);
            int max = int.Parse(numStrings[0]);

            foreach(string num in numStrings)
            {
                int cur = int.Parse(num);
                if (cur > max)
                {
                    max = cur;
                } else if (cur < min)
                {
                    min = cur;
                }
            }

            return max - min;
        }

        public static int GetSecondResult(String input)
        {
            StringReader reader = new StringReader(input);
            int sum = 0;

            while (reader.Peek() > -1)
            {
                sum += GetEvenlyDivisibleResult(reader.ReadLine().Split('\t'));
            }

            return sum;
        }

        private static int GetEvenlyDivisibleResult(string[] row)
        {
            List<int> ints = new List<int>();

            foreach (string numString in row)
            {
                ints.Add(int.Parse(numString));
            }

            ints.Sort();
            ints.Reverse();

            for (int i = 0; i < ints.Count; i++)
            {
                for (int j = i + 1; j < ints.Count; j++)
                {
                    if (ints[i] % ints[j] == 0)
                    {
                        return ints[i] / ints[j];
                    }
                }
            }

            return 0;
        }
    }
}