using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class Goods
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Num { get; set; }
        public Goods(string name, float price, int num)
        {
            this.Name = name;
            this.Price = price;
            this.Num = num;
        }

        //重写ToString()函数
        public override string ToString()
        {
            return "商品名称:" + Name + "  商品价格" + Price + "  商品数量" + Num;
        }

        //重写Equals()函数
        public override bool Equals(object  obj)
        {
            Goods other = obj as Goods;
            return other != null && other.Name == this.Name;
        }

        //重写GetHashCode()函数
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

    }
}
