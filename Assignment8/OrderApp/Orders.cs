﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApp
{
    public class Orders : IComparable<Orders>
    {

        [Key]
        public string OrderID { get; set; }
        public Clients Client { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get => (Client != null) ? Client.Name : ""; }
        public DateTime CreateTime {  get; set; }



        public List<OrderDetails> Details= new List<OrderDetails>();
        
        //订单总价格
        public float Amount
        {
            get => Details.Sum(d => d.TotalPrice);
        }

        public Orders(string orderId, Clients client) 
        {
            this.OrderID = orderId;
            this.Client = client;
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
            return 1651275338 + OrderID.GetHashCode();
        }

        //重写ToString()函数
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"订单编号:{OrderID}\t客户名称:{Client}\t创建日期：{CreateTime}");
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
