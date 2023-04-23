using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
     class main
    {
        public static void Main(string[] args)
        {
            Clients client1 = new Clients("Tom");
            Clients client2 = new Clients("Jerry");

            Goods bread = new Goods("bread", 5.0f, 50);
            Goods apple = new Goods("apple", 8.0f, 30);
            Goods shirt = new Goods("shirt", 99.0f, 15);
            Goods cup = new Goods("cup", 25.5f, 20);
            Goods pencil = new Goods("pencil", 2.0f, 100);

            Orders order1 = new Orders(001, client1, new DateTime(2023, 1, 21));
            Orders order2 = new Orders(002, client1, new DateTime(2023, 2, 28));
            Orders order3 = new Orders(003, client2, new DateTime(2023, 1, 21));

            order1.AddOrderDetail(new OrderDetails(bread, 3));
            order1.AddOrderDetail(new OrderDetails(apple, 8));
            order1.AddOrderDetail(new OrderDetails(cup, 2));

            order2.AddOrderDetail(new OrderDetails(shirt, 1));
            order2.AddOrderDetail(new OrderDetails(bread, 5));

            order3.AddOrderDetail(new OrderDetails(apple, 5));
            order3.AddOrderDetail(new OrderDetails(shirt, 2));
            order3.AddOrderDetail(new OrderDetails(cup, 4));
            order3.AddOrderDetail(new OrderDetails(pencil, 20));

            OrderService test = new OrderService();
            test.AddOrder(order1);
            test.AddOrder(order2);
            test.AddOrder(order3);

            //展示所有订单
            Console.WriteLine("显示所有订单");
            List<Orders> orders = test.GetAllOrders();
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n---------------------------------------------------");

            //根据ID查询订单
            Console.WriteLine("\n根据ID查询订单,查询订单001");
            Console.WriteLine(test.SearchByID(001));

            Console.WriteLine("\n---------------------------------------------------");

            //根据客户名字查询订单
            Console.WriteLine("\n根据客户名字查询订单，查询Tom");
            orders = test.SearchByClient("Tom");
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n---------------------------------------------------");

            //根据商品名称查询订单
            Console.WriteLine("\n根据商品名称查询订单，查询apple");
            orders = test.SearchByGoods("apple");
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n---------------------------------------------------");

            //根据创建日期查询订单
            Console.WriteLine("\n根据订单创建日期查询订单，查询2023-1-21");
            orders = test.SearchByTime(new DateTime(2023, 1, 21));
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n---------------------------------------------------");

            //修改订单
            Orders neworder1 = new Orders(001, client1, new DateTime(2023, 1, 21));
            neworder1.AddOrderDetail(new OrderDetails(bread, 50));
            neworder1.AddOrderDetail(new OrderDetails(apple, 8));
            neworder1.AddOrderDetail(new OrderDetails(cup, 2));
            test.ChangeOrder(neworder1 as Orders);
            Console.WriteLine("修改订单1，显示所有订单");        
            orders = test.GetAllOrders();
            orders.Sort();
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("\n---------------------------------------------------");

            //删除订单
            Console.WriteLine("删除订单2，显示所有订单");
            test.DeleteOrder(002);
            orders = test.GetAllOrders();
            orders.Sort();
            orders.ForEach(o => Console.WriteLine(o));
        }
    }
}
