namespace Main
{
    public class Day01
    {
        public static int GetFirstResult(string input)
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

        public static int GetSecondResult(string input)
        {
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