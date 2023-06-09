using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : Shape
    {
        public double[] Edges { get; set; } = new double[3];
        public Triangle(double a, double b, double c)
        {
            double[] newEdges = new double[3] { a, b, c };
            this.Edges = newEdges;
        }
        public double Area
        {
            get
            {
                if (!IsReal()) throw new InvalidOperationException("形状错误");
                double p = (Edges[0] + Edges[1] + Edges[2]) / 2;
                return Math.Sqrt(p * (p - Edges[0]) * (p - Edges[1]) * (p - Edges[2]));
            }
        }
        public bool IsReal()
        {
            double a = Edges[0], b = Edges[1], c = Edges[2];
            return (a > 0 && b > 0 && c > 0 &&
                    a + b > c && b + c > a && a + c > b);

        }
    }
}
