using System;
 namespace Assignment2
{
    class GetPrimeFactors
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"{num}的素数因子为：");
            
            for (int i = 2; i <= num; i++)
            {
                while (num % i == 0)  //能整除则不断除以这个因子
                {
                    num = num / i;
                    Console.WriteLine(i);
                }
            }
        }   
    }
}
