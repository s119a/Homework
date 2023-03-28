using System;
namespace Assignment2
{
    class SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            //设定要求的范围
            const int MAXNUM = 100;
            bool[] isPrime = new bool[MAXNUM + 1];
            //将数组初始化为全true
            for (int i = 0; i < MAXNUM; i++) 
            {
                isPrime[i] = true;
            }
            //进行筛选
            for (int i=2; i<=MAXNUM; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i*i;j <= MAXNUM; j+=i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            //输出
            Console.WriteLine($"2-{MAXNUM}的素数有：");
            for (int i = 2;i < MAXNUM; i++)
            {
                if (isPrime[i])
                {
                    Console.Write($"{i},");
                }
            }

        }
    }
}