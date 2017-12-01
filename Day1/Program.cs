using System;

namespace Day1
{
    public class Program
    {
        private const string InputFile = "C:/Users/Zlatko/source/repos/AoC-2017/Day1/input.txt";

        static void Main()
        {
            Console.WriteLine($"First result is {First.GetResult(InputFile)}");

            Console.WriteLine($"Second result is {Second.GetResult(InputFile)}");

            Console.ReadLine();
        }
    }
}