using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApp
{
    public class OrderDetails
    {
        [Key]
        public string Id { get; set; }
        public Goods Good  { get; set; }  //商品
        public int Quantity { get; set; }  //订购数量
        public float TotalPrice  //该商品总价
        {
            get => Quantity * Good.Price;
        }
        
        public OrderDetails(Goods good,int quantity) 
        {
            this.Id = Guid.NewGuid().ToString();
            this.Good = good;
            this.Quantity = quantity;
        }
        
        //重写ToString()函数
        public override string ToString()
        {
            return "商品名称：" + Good.Name + "\t商品单价:"+Good.Price+"\t商品数量：" + Quantity;
        }

        //重写Equals()函数
        public override bool Equals(object obj)
        {
            OrderDetails other = obj as OrderDetails;
            return other!=null&&other.Good==Good&&other.Quantity==Quantity;
        }

        //重写GetHashCode()函数
        public override int GetHashCode()
        {
            int hashCode = 497203120;
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(Good);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }




    }
}
