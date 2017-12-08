using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Main
{
    public class Day08
    {
        public static int GetFirstResult(string input)
        {
            StringReader reader = new StringReader(input);
            IDictionary<string, int> registers = new Dictionary<string, int>();

            while (reader.Peek() > -1)
            {
                string[] row = reader.ReadLine()?.Split(' ');
                if (!registers.ContainsKey(row[4]))
                {
                    registers.Add(row[4], 0);
                }
                if (!registers.ContainsKey(row[0]))
                {
                    registers.Add(row[0], 0);
                }
                if (GetFunc(row[5]).Invoke(registers[row[4]], int.Parse(row[6])))
                {
                    registers[row[0]] = GetOperation(row[1]).Invoke(registers[row[0]], int.Parse(row[2]));
                }
            }

            reader.Close();
            return registers.Values.Max();
        }

        public static int GetSecondResult(string input)
        {
            StringReader reader = new StringReader(input);
            IDictionary<string, int> registers = new Dictionary<string, int>();
            int? max = null;

            while (reader.Peek() > -1)
            {
                string[] row = reader.ReadLine()?.Split(' ');
                if (!registers.ContainsKey(row[4]))
                {
                    registers.Add(row[4], 0);
                }
                if (!registers.ContainsKey(row[0]))
                {
                    registers.Add(row[0], 0);
                }
                if (GetFunc(row[5]).Invoke(registers[row[4]], int.Parse(row[6])))
                {
                    registers[row[0]] = GetOperation(row[1]).Invoke(registers[row[0]], int.Parse(row[2]));
                    if (!max.HasValue || max.Value < registers[row[0]])
                    {
                        max = registers[row[0]];
                    }
                }
            }

            reader.Close();
            return max.Value;
        }

        private static Func<int, int, bool> GetFunc(string val)
        {
            switch (val)
            {
                case "==":
                    return (a, b) => a == b;
                case "!=":
                    return (a, b) => a != b;
                case "<=":
                    return (a, b) => a <= b;
                case ">=":
                    return (a, b) => a >= b;
                case "<":
                    return (a, b) => a < b;
                case ">":
                    return (a, b) => a > b;
                default:
                    throw new NotImplementedException();
            }
        }

        private static Func<int, int, int> GetOperation(string val)
        {
            switch (val)
            {
                case "inc":
                    return (a, b) => a + b;
                case "dec":
                    return (a, b) => a - b;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}