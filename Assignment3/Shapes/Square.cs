using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shape
    {

        public double Side { get; set; }
        public Square(double Side)
        {
            this.Side = Side;
        }
        public double Area
        {
            get
            {
                if (!IsReal()) throw new InvalidOperationException("形状错误");
                return Side * Side;
            }
        }

        public bool IsReal()
        {
            return Side > 0;
        }
    }
}
