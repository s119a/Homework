using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{

    public class ShapeFactory
    {
        public enum ShapeType { Squre, Circle, Rectangle, Triangle };
        static readonly int[] edgeNumbers = { 1, 1, 2, 3 };
        static readonly Random random = new Random();

        //根据类型和参数创建形状
        public static Shape CreateShape(ShapeType type, double[] edges)
        {
            if (edges == null)
                throw new InvalidOperationException("edges cannot be null");
            int index = Convert.ToInt32(type);
            if (edges.Length != edgeNumbers[index])
            {
                throw new InvalidOperationException("invalid edge number");
            }

            Shape result = null;
            switch (type)
            {
                case ShapeType.Squre:
                    result = new Square(edges[0]);
                    break;
                case ShapeType.Circle:
                    result = new Circle(edges[0]);
                    break;
                case ShapeType.Rectangle:
                    result = new Rectangle(edges[0], edges[1]);
                    break;
                case ShapeType.Triangle:
                    result = new Triangle(edges[0], edges[1], edges[2]);
                    break;
                default:
                    throw new InvalidOperationException("Invalid shape type:" + type);
            }

            if (!result.IsReal())
            {
                throw new InvalidOperationException("Invalid shape arguments");
            }

            return result;
        }

        //随机创建形状
        public static Shape CreateRandomShape()
        {
            int index = random.Next(0, 4);
            ShapeType type = (ShapeType)Enum.Parse(
                        typeof(ShapeType), index.ToString());
            double[] edges = new double[edgeNumbers[index]];

            Shape result = null;
            do
            {
                try
                {
                    for (int i = 0; i < edgeNumbers[index]; i++)
                    {
                        edges[i] = random.Next(200);
                    }
                    result = CreateShape(type, edges);
                }
                catch { }//忽略异常

            } while (result == null);

            return result;
        }
    }
}
