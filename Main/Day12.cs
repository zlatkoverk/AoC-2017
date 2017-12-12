using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Main
{
    public class Day12
    {
        private static int? _secondResult;

        public static int GetFirstResult(string input)
        {
            StringReader reader = new StringReader(input);
            IList<ISet<int>> groups = new List<ISet<int>>();

            while (reader.Peek() > -1)
            {
                string[] row = reader.ReadLine().Trim().Split(new string[]{" <-> "}, StringSplitOptions.None);
                List<string> elements = row[1].Split(new[]{", "}, StringSplitOptions.None).ToList();
                elements.Insert(0, row[0]);

                Connect(groups, elements.ToArray());
            }

            reader.Close();
            while (ConnectGroups(groups))
            {
            }
            _secondResult = groups.Count;
            return groups.FirstOrDefault(group => group.Contains(0)).Count;
        }

        public static int GetSecondResult(string input)
        {
            if (!_secondResult.HasValue)
            {
                GetFirstResult(input);
            }
            return _secondResult.Value;
        }

        private static void Connect(IList<ISet<int>> groups, string[] row)
        {
            int groupIndex = -1;
            for (int i = 0; i < groups.Count; i++)
            {
                foreach (string element in row)
                {
                    if (groups[i].Contains(int.Parse(element)))
                    {
                        groupIndex = i;
                        break;
                    }
                }
                if (groupIndex > -1)
                {
                    break;
                }
            }

            if (groupIndex == -1)
            {
                groups.Add(new SortedSet<int>());
                groupIndex = groups.Count - 1;
            }

            foreach (string element in row)
            {
                groups[groupIndex].Add(int.Parse(element));
            }
        }

        private static bool ConnectGroups(IList<ISet<int>> groups)
        {
            for (int i = 0; i < groups.Count; i++)
            {
                for (int j = i + 1; j < groups.Count; j++)
                {
                    if (groups[i].Overlaps(groups[j]))
                    {
                        groups[i].UnionWith(groups[j]);
                        groups.RemoveAt(j);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}