using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class Orders : IComparable<Orders>
    {
        public int OrderID { get; set; }
        public Clients Client { get; set; }
        public DateTime CreateTime {  get; set; }
        public string ToDateString()
        {
            return CreateTime.ToString("yyyy-MM-dd");
        }


        public List<OrderDetails> Details= new List<OrderDetails>();
        
        //订单总价格
        public float Amount
        {
            get => Details.Sum(d => d.TotalPrice);
        }

        public Orders(int orderid,Clients client,DateTime creattime) 
        {
            this.OrderID = orderid;
            this.Client = client;
            this.CreateTime = creattime;
        }

        //重写Equals()函数
        public override bool Equals(object obj)
        {
            var order = obj as Orders;
            return order != null && OrderID == order.OrderID;
        }

        //重写GetHashCode()函数
        public override int GetHashCode()
        {
            return HashCode.Combine(OrderID);
        }

        //重写ToString()函数
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"订单编号:{OrderID}\t客户名称:{Client}\t创建日期：{this.ToDateString()}");
            Details.ForEach(detail => result.Append("\n\t" + detail));
            result.Append($"\n订单总价:{Amount}\n");
            return result.ToString();
        }
        //CompareTo()函数
        public int CompareTo(Orders o)
        {
            Orders order = o as Orders;
            if (order == null)
            {
                throw new System.ArgumentException();
            }
            return this.OrderID.CompareTo(order.OrderID);
        }

        public void AddOrderDetail(OrderDetails orderDetail)
        {
            if (Details.Contains(orderDetail))
            {
                throw new ApplicationException($"The goods ({orderDetail.Good.Name}) exist in order {OrderID}");
            }
            Details.Add(orderDetail);
        }


    }
}
