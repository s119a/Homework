using System;
namespace Assignment2
{
    class GetNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入整数并以逗号隔开");
            string[] input = Console.ReadLine().Split(",");
            int[] num = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                num[i] = int.Parse(input[i]);
            }
            //求最大值
            int max = num[0];
            for (int j = 1; j < num.Length; j++)
            {
                if (max <= num[j])
                {
                    max = num[j];
                }
            }
            //求最小值
            int min = num[0];
            for (int j = 1; j < num.Length; j++)
            {
                if (min >= num[j])
                {
                    min = num[j];
                }
            }
            //求总和
            int sum = num[0];
            for (int j = 1; j < num.Length; j++)
            {
                sum += num[j];
            }
            //求平均值
            int average = sum / num.Length;
            Console.WriteLine($"最大值={max}");
            Console.WriteLine($"最小值={min}");
            Console.WriteLine($"平均值={average}");
            Console.WriteLine($"总和={sum}");
        }
    }
}
