using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle:Shape
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public Rectangle(double length, double width)
        {
            this.Length = length;
            this.Width = width;
        }

        public double Area
        {
            get
            {
                if (!IsReal()) throw new InvalidOperationException("形状错误");
                return Length * Width;
            }
        }
        public bool IsReal()
        {
            return Length > 0 && Width > 0;
        }
    };
}
