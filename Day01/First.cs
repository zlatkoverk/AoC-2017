﻿namespace Day01
{
    public class First
    {
        public static int GetResult(string input)
        {
            int sum = 0;
            for (int i = 1; i <= input.Length; i++)
            {
                if (input[i % input.Length] == input[i - 1])
                {
                    sum += input[i - 1] - '0';
                }
            }

            return sum;
        }
    }
}
