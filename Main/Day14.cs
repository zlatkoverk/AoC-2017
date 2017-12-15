using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class Day14
    {
        private static IList<IList<bool>> table;
        private static int groups;

        public static int GetFirstResult(String input)
        {
            IList<string> rows = new List<string>();
            for (int i = 0; i < 128; i++)
            {
                rows.Add(Day10.GetSecondResult(input + "-" + i));
            }

            table = new List<IList<bool>>();
            int k = 0;
            foreach (string s in rows)
            {
                table.Add(new List<bool>());
                foreach (char c in s)
                {
                    int num = int.Parse(c.ToString(), System.Globalization.NumberStyles.HexNumber);
                    for (int i = 3; i >= 0; --i)
                    {
                        table[table.Count - 1].Add(((num >> i) & 1) == 1);
                        k += (num >> i) & 1;
                    }
                }
            }

            return k;
        }

        public static int GetSecondResult(string input)
        {
            if (table == null)
            {
                GetFirstResult(input);
            }

            groups = 0;
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    if (table[i][j])
                    {
                        Remove(i, j);
                        groups++;
                    }
                }
            }

            return groups;
        }

        private static void Remove(int i, int j)
        {
            if (i < 0 || i > 127 || j < 0 || j > 127)
            {
                return;
            }
            if (!table[i][j])
            {
                return;
            }
            table[i][j] = false;
            Remove(i, j - 1);
            Remove(i - 1, j);
            Remove(i, j + 1);
            Remove(i + 1, j);
        }
    }
}