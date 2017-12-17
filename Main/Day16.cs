using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Main
{
    public class Day16
    {

        private static IList<char> list;
        private static string[] moves;

        public static string GetFirstResult(string input)
        {
            if (list == null)
            {
                list = new List<char>();
                for (int i = 0; i < 16; i++)
                {
                    list.Add((char)('a' + i));
                }
                moves = input.Split(',');
            }

            foreach (string s in moves)
            {
                Move(s, list);
            }

            StringBuilder sb = new StringBuilder();
            foreach (char c in list)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        public static string GetSecondResult(string input)
        {
            list = null;
            ISet<string> iterations = new HashSet<string>();
            bool cut = false;
            for (int i = 0; i < 1000000000; i++)
            {
                if (!iterations.Add(GetFirstResult(input)) && !cut)
                {
                    i = 1000000000 - 1000000000 % i;
                    cut = true;
                }

            }
            StringBuilder sb = new StringBuilder();
            foreach (char c in list)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        private static void Move(string s, IList<char> list)
        {
            if (s[0] == 's')
            {
                int num = int.Parse(s.Substring(1));
                for (int i = 0; i < num; i++)
                {
                    list.Insert(0, list[list.Count - 1]);
                    list.RemoveAt(list.Count - 1);
                }
                return;
            }
            if (s[0] == 'x')
            {
                string[] nums = s.Substring(1).Split('/');
                int pos1 = int.Parse(nums[0]);
                int pos2 = int.Parse(nums[1]);
                char pom = list[pos1];
                list[pos1] = list[pos2];
                list[pos2] = pom;
                return;
            }
            if (s[0] == 'p')
            {
                string[] nums = s.Substring(1).Split('/');
                int pos1 = list.IndexOf(nums[0][0]);
                int pos2 = list.IndexOf(nums[1][0]);
                char pom = list[pos1];
                list[pos1] = list[pos2];
                list[pos2] = pom;
                return;
            }
        }
    }
}