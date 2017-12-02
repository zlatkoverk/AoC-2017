using System;

namespace Main
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(
                $"Day01: {Day01.GetFirstResult(Util.GetInputForDay(1))} {Day01.GetSecondResult(Util.GetInputForDay(1))}");

            Console.WriteLine($"Day02: {Day02.GetFirstResult(Util.GetInputForDay(2))} {Day02.GetSecondResult(Util.GetInputForDay(2))}");

            Console.Read();
        }
    }
}
