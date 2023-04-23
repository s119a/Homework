using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class OrderService
    {
        public List<Orders> orders=new List<Orders>();

        public OrderService() { }

        //添加新订单
        public void AddOrder(Orders newOrder)
        {
            if (orders.Contains(newOrder))
            {
                throw new ApplicationException("订单已存在");
            }
            orders.Add(newOrder);
        }

        //删除订单
        public void DeleteOrder(int id)
        {
            int idx = orders.FindIndex(o => o.OrderID == id);
            if (id < 0)
            {
                throw new ApplicationException("该订单不存在");
            }
            orders.RemoveAt(idx);
        }

        //修改订单
        public void ChangeOrder(Orders newOrder)
        {
            int id = orders.FindIndex(o => o.OrderID == newOrder.OrderID);
            if (id < 0)
            {
                throw new ApplicationException($"编号为{newOrder.OrderID}的订单不存在");
            }
            orders.RemoveAt(id);
            orders.Add(newOrder);
        }

        //根据ID查询订单
        public Orders SearchByID(int id)
        {
            if(orders.FirstOrDefault(o => o.OrderID == id)==null)
            {
                throw new ApplicationException($"您查询的订单不存在");
            }
            return orders.FirstOrDefault(o => o.OrderID == id);
        }

        //根据客户名字查询订单
        public List<Orders> SearchByClient(string clientName)
        {
            var quary=orders
                .Where(o=>o.Client.Name==clientName)
                .OrderByDescending(o=>o.Amount);
            if (quary == null)
            {
                throw new ApplicationException($"您查询的订单不存在");
            }
            return quary.ToList();
        }

        //根据商品名称查询订单
        public List<Orders> SearchByGoods(string goodsName)
        {
            var quary=orders
                .Where(o=>o.Details.Any(s=>s.Good.Name==goodsName))
                .OrderByDescending(o=>o.Amount);
            if (quary == null)
            {
                throw new ApplicationException($"您查询的订单不存在");
            }
            return quary.ToList();
        }

        //根据订单创建时间查询订单
        public List<Orders> SearchByTime(DateTime time)
        {
            var quary=orders
                .Where(o=>o.CreateTime==time)
                .OrderByDescending(o=>o.Amount);
            if (quary == null)
            {
                throw new ApplicationException($"您查询的订单不存在");
            }
            return quary.ToList();
        }

        //获取所有订单
        public List<Orders> GetAllOrders()
        {
            return orders;
        }

        //给订单排序
        public void Sort(Comparison<Orders> comparison)
        {
            orders.Sort(comparison);
        }
    }
}
