using Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shapes
{

    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                List<Shape> shapes = new List<Shape>();
                for (int i = 0; i < 10; i++)
                {
                    shapes.Add(ShapeFactory.CreateRandomShape());
                }
                shapes.ForEach(s =>
                  Console.WriteLine($"area={s.Area}"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}

