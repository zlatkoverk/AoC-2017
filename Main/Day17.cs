using System.Collections.Generic;

namespace Main
{
    public class Day17
    {
        public static int GetFirstResult(string input)
        {
            IList<int> list = new List<int>();
            list.Add(0);
            int moves = int.Parse(input);
            int curPos = 0;
            for (int i = 1; i < 2018; i++)
            {
                curPos = (curPos + moves) % list.Count;
                list.Insert(++curPos % (i + 1), i);
            }

            return list[++curPos];
        }

        public static int GetSecondResult(string input)
        {
            int moves = int.Parse(input);
            int curPos = 0;
            int afterZero = 1;
            for (int i = 1; i < 50000001; i++)
            {
                curPos = (curPos + moves) % i;
                curPos++;
                if (curPos == 1)
                {
                    afterZero = i;
                }
            }

            return afterZero;
        }
    }
}