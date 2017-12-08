using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;

namespace Main
{
    public class Day07
    {
        public static string GetFirstResult(string input)
        {
            if (Program.Programs.Count == 0)
            {
                ProcessInput(input);
            }

            foreach (Program program in Program.Programs.Values)
            {
                if (!program.IsChild())
                {
                    return program.Name;
                }
            }

            return null;
        }

        public static int GetSecondResult(string input)
        {
            if (Program.Programs.Count == 0)
            {
                ProcessInput(input);
            }

            Program topProgram = Program.Programs[GetFirstResult(input)];

            while (topProgram.NotBalancedChild() != null)
            {
                topProgram = topProgram.NotBalancedChild();
            }

            int childrenWeight = topProgram.GetWeight() - topProgram.Value;

            return topProgram.Parent.BalancedChild().GetWeight() - childrenWeight;
        }



        private static void ProcessInput(string input)
        {
            ISet<Program> programs = new HashSet<Program>();
            StringReader reader = new StringReader(input);

            while (reader.Peek() > -1)
            {
                string row = reader.ReadLine();
                Program.CreateProgram(row);
            }

            reader.Close();
        }


        public class Program
        {
            public static readonly IDictionary<string, Program> Programs = new Dictionary<string, Program>();
            public ISet<Program> Children { get; }
            public Program Parent { get; set; }
            public string Name { get; set; }
            public int Value { get; set; }

            private Program(string name, int value = 0)
            {
                Children=new HashSet<Program>();
                Name = name;
                Value = value;
            }

            public static Program CreateProgram(string data)
            {
                string[] fields = data.Split(new string[] {" -> "}, StringSplitOptions.None);
                string name = fields[0].Split(' ')[0];
                string value = fields[0].Split(' ')[1];
                value = value.Substring(1, value.Length - 2);
                if (fields.Length == 1)
                {
                    return CreateOrGetProgram(name, int.Parse(value));
                }
                else
                {
                    string[] children = fields[1].Split(new string[] { ", " }, StringSplitOptions.None);
                    Program p = CreateOrGetProgram(name, int.Parse(value));
                    foreach (string child in children)
                    {
                        Program childProgram = CreateOrGetProgram(child);
                        p.Children.Add(childProgram);
                        childProgram.Parent = p;
                    }
                    return p;
                }
            }

            private static Program CreateOrGetProgram(string name, int value = 0)
            {
                if (Programs.ContainsKey(name))
                {
                    if (Programs[name].Value == 0)
                    {
                        Programs[name].Value = value;
                    }
                    return Programs[name];
                }
                else
                {
                    Programs.Add(name, new Program(name, value));
                    return Programs[name];
                }
            }

            public bool IsChild()
            {
                foreach (Program p in Programs.Values)
                {
                    if (p.Children.Contains(this))
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetWeight()
            {
                int weight = Value;
                foreach (Program child in Children)
                {
                    weight += child.GetWeight();
                }
                return weight;
            }

            public Program NotBalancedChild()
            {
                return Children.FirstOrDefault(child => child.GetWeight() == Children.GroupBy(c => c.GetWeight()).Where(group=>group.Count()==1).Select(group=>group.Key).FirstOrDefault());
            }

            public Program BalancedChild()
            {
                return Children.FirstOrDefault(child => child.GetWeight() == Children.GroupBy(c => c.GetWeight()).Where(group => group.Count() != 1).Select(group => group.Key).FirstOrDefault());
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Program))
                {
                    return false;
                }
                Program other = (Program) obj;
                return other.Name == Name;
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}