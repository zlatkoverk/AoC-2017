using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Main
{
    public class Day05
    {
        public static int GetFirstResult(String input)
        {
            IList<int> jumps = ReadInput(input);

            int i = 0;
            int cnt = 0;
            while (i >= 0 && i < jumps.Count)
            {
                int j = i;
                i += jumps[i];
                jumps[j]++;
                cnt++;
            }

            return cnt;
        }

        public static int GetSecondResult(String input)
        {
            IList<int> jumps = ReadInput(input);

            int i = 0;
            int cnt = 0;
            while (i >= 0 && i < jumps.Count)
            {
                int j = i;
                i += jumps[i];
                if (jumps[j] >= 3)
                {
                    jumps[j]--;
                }
                else
                {
                    jumps[j]++;
                }
                cnt++;
            }

            return cnt;
        }

        private static IList<int> ReadInput(String input)
        {
            StringReader reader = new StringReader(input);
            IList<int> jumps = new List<int>();

            while (reader.Peek() > -1)
            {
                jumps.Add(int.Parse(reader.ReadLine()));
            }

            reader.Close();
            return jumps;
        }
    }
}