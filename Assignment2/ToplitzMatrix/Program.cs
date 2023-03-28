using System;
using System.Security.Cryptography.X509Certificates;

namespace Assignment2
{
    public class ToplitzMatrix
    {
        public static void Main(string[] args)
        {
            Console.Write("请输入行数:");
            int row=int.Parse(Console.ReadLine());
            Console.Write("请输入列数:");
            int col=int.Parse(Console.ReadLine());
            int[][] matrix = new int[row][];
            for(int i = 0; i < row; i++)
            {
                matrix[i] = new int[col];   
                Console.Write($"请输入第{i+1}行的数并以逗号隔开：");
                string[] input= Console.ReadLine().Split(",");
                for (int j = 0; j < col; j++)
                {
                    matrix[i][j] = int.Parse(input[j]);
                }
            }
            //判断是否为托普利茨矩阵
            static bool isToplitzMatrix(int[][] matrix)
            {
                int row=matrix.Length;
                int col = matrix[0].Length;
                for (int i = 1;i < row; i++)
                {
                    for (int j = 1;j < col; j++)
                    {
                        if (matrix[i][j] != matrix[i - 1][j-1])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            if ( isToplitzMatrix(matrix) )
            {
                Console.WriteLine("该矩阵是托普利茨矩阵");
            }
            else
            {
                Console.WriteLine("该矩阵不是托普利茨矩阵");
            }
        }


    }
}
