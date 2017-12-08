using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class Day06
    {
        public static int GetFirstResult(String input)
        {
            IList<int> current = GetInput(input);

            IList<IList<int>> states = new List<IList<int>>();
            states.Add(current);

            do
            {
                current = CalcNewState(current);
                states.Add(current);
            } while (LastDoesntHaveDuplicate(states));

            return states.Count - 1;
        }

        public static int GetSecondResult(String input)
        {
            IList<int> current = GetInput(input);

            IList<IList<int>> states = new List<IList<int>>();
            states.Add(current);

            do
            {
                current = CalcNewState(current);
                states.Add(current);
            } while (!IndexOfDuplicate(states).HasValue);

            return states.Count - IndexOfDuplicate(states).Value - 1;
        }

        private static int? IndexOfDuplicate(IList<IList<int>> states)
        {
            for (int i = 0; i < states.Count - 1; i++)
            {
                if (states[i].SequenceEqual(states[states.Count - 1]))
                {
                    return i;
                }
            }
            return null;
        }

        private static bool LastDoesntHaveDuplicate(IList<IList<int>> states)
        {
            for (int i = 0; i < states.Count-1; i++)
            {
                if (states[i].SequenceEqual(states[states.Count-1]))
                    {
                        return false;
                    }
            }
            return true;
        }

        private static IList<int> CalcNewState(IList<int> state)
        {
            IList<int> next = new List<int>();
            int highest = state.IndexOf(state.Max());
            for (int i = 0; i < state.Count; i++)
            {
                if (i == highest)
                {
                    next.Add(0);
                }
                else
                {
                    next.Add(state[i]);
                }
            }
            for (int i = highest + 1, n = state[highest]; n > 0; i++, n--)
            {
                next[i % state.Count]++;
            }
            return next;
        }

        private static IList<int> GetInput(string input)
        {
            string[] inStrings = input.Split('\t');
            IList<int> list = new List<int>();
            foreach (string s in inStrings)
            {
                list.Add(int.Parse(s));
            }
            return list;
        }
    }
}