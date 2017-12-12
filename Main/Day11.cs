using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Main
{
    public class Day11
    {
        public static int GetFirstResult(string input)
        {
            string[] path = input.Split(',');

            int ne = path.Where(p => p == "ne").Count();
            int sw = path.Where(p => p == "sw").Count();
            int n = path.Where(p => p == "n").Count();
            int s = path.Where(p => p == "s").Count();
            int nw = path.Where(p => p == "nw").Count();
            int se = path.Where(p => p == "se").Count();

            bool changed;
            do
            {
                changed = false;
                if(Math.Min(ne, s) > 0)
                {
                    int tmp = Math.Min(ne, s);
                    ne -= tmp;
                    s -= tmp;
                    se += tmp;
                    changed = true;
                }
                if (Math.Min(se, sw) > 0)
                {
                    int tmp = Math.Min(se, sw);
                    se -= tmp;
                    sw -= tmp;
                    s += tmp;
                    changed = true;
                }
                if (Math.Min(nw, s) > 0)
                {
                    int tmp = Math.Min(nw, s);
                    nw -= tmp;
                    s -= tmp;
                    sw += tmp;
                    changed = true;
                }
                if (Math.Min(nw, ne) > 0)
                {
                    int tmp = Math.Min(nw, ne);
                    nw -= tmp;
                    ne -= tmp;
                    n += tmp;
                    changed = true;
                }
                if (Math.Min(n, sw) > 0)
                {
                    int tmp = Math.Min(n, sw);
                    n -= tmp;
                    sw -= tmp;
                    nw += tmp;
                    changed = true;
                }
                if (Math.Min(n, se) > 0)
                {
                    int tmp = Math.Min(n, se);
                    n -= tmp;
                    se -= tmp;
                    ne += tmp;
                    changed = true;
                }
            } while (changed);

            return Math.Abs(ne - sw) + Math.Abs(n - s) + Math.Abs(nw - se);
        }

        public static int GetSecondResult(string input)
        {
            int max = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',')
                {
                    max = Math.Max(max, GetFirstResult(input.Substring(0, i - 1)));
                }
            }
            return Math.Max(max, GetFirstResult(input));
        }
    }
}