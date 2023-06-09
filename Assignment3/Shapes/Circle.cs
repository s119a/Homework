using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Area
        {
            get
            {
                if (!IsReal()) throw new InvalidOperationException("形状错误");
                return Math.PI * Radius * Radius;
            }
        }

        public bool IsReal()
        {
            return Radius > 0;
        }
    }
}
