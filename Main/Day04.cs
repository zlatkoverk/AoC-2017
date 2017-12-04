using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Main
{
    public class Day04
    {
        public static int GetFirstResult(String input)
        {
            StringReader reader = new StringReader(input);

            int valid = 0;
            while (reader.Peek() > -1)
            {
                valid += IsValid(reader.ReadLine()) ? 1 : 0;
            }

            reader.Close();
            return valid;
        }

        private static Boolean IsValid(String passphrase)
        {
            ISet<string> words = new HashSet<string>();
            string[] passStrings = passphrase.Split(' ');

            foreach (string passString in passStrings)
            {
                if (!words.Add(passString))
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetSecondSolution(String input)
        {
            StringReader reader = new StringReader(input);

            int valid = 0;
            while (reader.Peek() > -1)
            {
                valid += ContainsAnagram(reader.ReadLine()) ? 0 : 1;
            }

            reader.Close();
            return valid;
        }

        private static bool ContainsAnagram(string passphrase)
        {
            IList<IDictionary<char, int>> words = new List<IDictionary<char, int>>();
            string[] wordStrings = passphrase.Split(' ');

            foreach (string wordString in wordStrings)
            {
                IDictionary<char, int> word = new Dictionary<char, int>();
                foreach (char c in wordString)
                {
                    if (word.ContainsKey(c))
                    {
                        word[c]++;
                    }
                    else
                    {
                        word[c] = 1;
                    }
                }

                words.Add(word);
            }

            for (int i = 0; i < words.Count; i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    if (words[i].OrderBy(kvp => kvp.Key).SequenceEqual(words[j].OrderBy(kvp => kvp.Key)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}