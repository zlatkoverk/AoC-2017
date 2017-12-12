using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Main
{
    public class Day10
    {
        public static int GetFirstResult(string input)
        {
            IList<int> list = new List<int>();
            for (int i = 0; i < 256; i++)
            {
                list.Add(i);
            }

            int pos = 0;
            int skipSize = 0;
            string[] lengthStrings = input.Split(',');
            foreach (string s in lengthStrings)
            {
                int length = int.Parse(s);
                Reverse(list, pos, length);
                pos += length + skipSize++;
            }

            return list[0] * list[1];
        }

        public static string GetSecondResult(string input)
        {
            IList<int> list = new List<int>();
            for (int i = 0; i < 256; i++)
            {
                list.Add(i);
            }
            input = input.Trim();
            IList<int> lengths = ConvertInput($"{input}{(char) 17}{(char) 31}{(char) 73}{(char) 47}{(char) 23}");

            int pos = 0;
            int skipSize = 0;
            for (int i = 0; i < 64; i++)
            {
                foreach (int length in lengths)
                {
                    Reverse(list, pos, length);
                    pos += length + skipSize++;
                    pos %= list.Count;
                }
            }

            IList<int> denseHash = new List<int>();
            for (int i = 0; i < list.Count / 16; i++)
            {
                int result = list[i * 16];
                for (int j = 1; j < 16; j++)
                {
                    result ^= list[i * 16 + j];
                }
                denseHash.Add(result);
            }

            StringBuilder builder = new StringBuilder();
            foreach (int i in denseHash)
            {
                builder.Append(i.ToString("x2"));
            }

            return builder.ToString();
        }

        private static IList<int> ConvertInput(string input)
        {
            IList<int> values = new List<int>();

            foreach (char c in input)
            {
                values.Add((int) c);
            }

            return values;
        }

        private static void Reverse(IList<int> list, int from, int length)
        {
            for (int i = 0; i < length / 2; i++)
            {
                int pom = list[(from + i) % list.Count];
                list[(from + i) % list.Count] = list[(from + length - i - 1) % list.Count];
                list[(from + length - i - 1) % list.Count] = pom;
            }
        }
    }
}