﻿using System.IO;

namespace Day1
{
    public class Second
    {
        public static int GetResult(string inputFilePath)
        {
            string input = File.ReadAllText(inputFilePath);

            int sum = 0;
            int offset = input.Length / 2;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i % input.Length] == input[(i + offset) % input.Length])
                {
                    sum += input[i % input.Length] - '0';
                }
            }

            return sum;
        }
    }
}