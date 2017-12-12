using System;
using System.IO;

namespace Main
{
    public class Day09
    {
        public static int GetFirstResult(string input)
        {
            StringReader reader = new StringReader(input);

            int sum = 0;
            int depth = 0;
            bool garbage = false;
            while (reader.Peek() > -1)
            {
                char c = (char)reader.Read();
                switch (c)
                {
                    case '{':
                        if (!garbage)
                            depth++;
                        break;
                    case '}':
                        if (!garbage)
                            sum += depth--;
                        break;
                    case '!':
                        reader.Read();
                        break;
                    case '<':
                        garbage = true;
                        break;
                    case '>':
                        garbage = false;
                        break;
                }
            }

            reader.Close();
            return sum;
        }

        public static int GetSecondResult(string input)
        {
            StringReader reader = new StringReader(input);

            int sum = 0;
            int depth = 0;
            int gar = 0;
            bool garbage = false;
            while (reader.Peek() > -1)
            {
                char c = (char)reader.Read();
                switch (c)
                {
                    case '{':
                        if (!garbage)
                            depth++;
                        else
                            gar++;
                        break;
                    case '}':
                        if (!garbage)
                            sum += depth--;
                        else
                            gar++;
                        break;
                    case '!':
                        reader.Read();
                        break;
                    case '<':
                        if (garbage)
                            gar++;
                        garbage = true;
                        break;
                    case '>':
                        garbage = false;
                        break;
                    default:
                        if (garbage)
                            gar++;
                        break;
                }
            }

            reader.Close();
            return gar;
        }
    }
}