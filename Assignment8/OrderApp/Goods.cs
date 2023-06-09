using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApp
{
    public class Goods
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Goods(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Goods() { }

        //重写ToString()函数
        public override string ToString()
        {
            return "商品名称:" + Name + "  商品价格" + Price ;
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
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
