using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.Cms;

namespace OrderApp
{
    public class OrderService
    {

        public List<Orders> Orders
        {
            get
            {
                using (var ctx = new OrderContext())
                {
                    return ctx.Orders
                      .Include(o => o.Details.Select(d => d.Good))
                      .Include(o => o.Client)
                      .ToList<Orders>();
                }
            }
        }
        public OrderService()
        {
            using (var ctx = new OrderContext())
            {
                if (ctx.Goods.Count() == 0)
                {
                    ctx.Goods.Add(new Goods("apple", 100));
                    ctx.Goods.Add(new Goods("egg", 200));
                    ctx.SaveChanges();
                }
                if (ctx.Clients.Count() == 0)
                {
                    ctx.Clients.Add(new Clients("li"));
                    ctx.Clients.Add(new Clients("zhang"));
                    ctx.SaveChanges();
                }
            }
        }

        //添加新订单
        public void AddOrder(Orders newOrder)
        {
            using (var ctx = new OrderContext())
            {
                ctx.Entry(newOrder).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        //删除订单
        public void DeleteOrder(string id)
        {
            int idx = Orders.FindIndex(o => o.OrderID == id);
            using (var ctx = new OrderContext())
            {
                var order = ctx.Orders.Include("Details")
                  .SingleOrDefault(o => o.OrderID == id);
                if (order == null) return;
                ctx.OrderDetails.RemoveRange(order.Details);
                ctx.Orders.Remove(order);
                ctx.SaveChanges();
            }
        }

        //修改订单
        public void ChangeOrder(Orders newOrder)
        {
            DeleteOrder(newOrder.OrderID);
            AddOrder(newOrder);
        }

        //根据ID查询订单
        public Orders SearchByID(string id)
        {
            using (var ctx = new OrderContext())
            {
                return (Orders)ctx.Orders
                  .Include("Customer")
                .Where(d => d.OrderID == id);
            }
        }

        //根据客户名字查询订单
        public List<Orders> SearchByClient(string clientName)
        {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.Good))
                  .Include(o => o.Client)
                  .Where(order => order.Client.Name == clientName)
                  .ToList();
            }
        }

        //根据商品名称查询订单
        public List<Orders> SearchByGoods(string goodsName)
        {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.Good))
                  .Include(o => o.Client)
                  .Where(order => order.Details.Any(item => item.Good.Name == goodsName))
                  .ToList();
            }
        }

        //根据订单创建时间查询订单
        public List<Orders> SearchByTime(DateTime time)
        {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                  .Include("Customer")
                .Where(d => d.CreateTime == time)
                .ToList();
            }
        }

        //获取所有订单
        public List<Orders> GetAllOrders()
        {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                .ToList();
            }
        }
    }
}
