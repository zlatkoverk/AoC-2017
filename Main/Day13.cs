using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Main
{
    public class Day13
    {
        public static int GetFirstResult(string input)
        {
            IDictionary<int, int> values = ReadInput(input);
            int result = 0;

            for (int i = 0; i <= values.Keys.Max(); i++)
            {
                if (values.Keys.Contains(i) && GetPos(values[i], i) == 0)
                {
                    result += i * values[i];
                }
            }

            return result;
        }

        public static int GetSecondResult(string input)
        {
            IDictionary<int, int> values = ReadInput(input);
            int d = 0;
            while (true)
            {
                bool found = false;

                for (int i = 0; i <= values.Keys.Max() && !found; i++)
                {
                    if (values.Keys.Contains(i) && (d + i) % (2 * (values[i] - 1)) == 0)
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    return d;
                }
                else
                {
                    d++;
                }
            }
        }

        private static int GetPos(int size, int iteration)
        {
            Func<int, int> curFunc = a => a + 1;
            int k = 0;
            for (int i = 0; i < iteration; i++, k = curFunc(k))
            {
                if (k == size - 1)
                {
                    curFunc = a => a - 1;
                }
                else if (k == 0)
                {
                    curFunc = a => a + 1;
                }
            }
            return k;
        }

        private static IDictionary<int, int> ReadInput(string input)
        {
            IDictionary<int, int> vals = new Dictionary<int, int>();
            StringReader reader = new StringReader(input);

            while (reader.Peek() > -1)
            {
                string[] row = reader.ReadLine().Split(new[] { ": " }, StringSplitOptions.None);
                vals.Add(int.Parse(row[0]), int.Parse(row[1]));
            }

            reader.Close();
            return vals;
        }
    }
}