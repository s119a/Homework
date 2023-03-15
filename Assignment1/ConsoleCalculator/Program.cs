namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入数字：");
            double a = Convert.ToSingle(Console.ReadLine());
            Console.Write("请输入数字：");
            double b = Convert.ToSingle(Console.ReadLine());
            Console.Write("请输入运算方式：");
            char op = Convert.ToChar(Console.ReadLine());
            double c = 0;
            switch (op)
            {
                case '+':
                    c = a + b;
                    break;
                case '-':
                    c = a - b;
                    break;
                case '*':
                    c = a * b;
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("error!");
                    }
                    else
                    {
                        c = a / b;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("结果=" + c);
        }
    }
}