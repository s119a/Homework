using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService os = new OrderService();
            Clients Client1 = new Clients("Cli1");
            Clients Client2 = new Clients("Cli2");
            Clients Client3 = new Clients("Cli3");
            Goods apple = new Goods("apple",3);
            Goods egg = new Goods("egg", 3);
            Goods milk = new Goods("milk", 3);
            Orders order1 = new Orders("1", Client1);
            Orders order2 = new Orders("2", Client2);
            Orders order3 = new Orders("3", Client3);
            OrderDetails detail1 = new OrderDetails(apple,10);
            OrderDetails detail2 = new OrderDetails(apple, 30);
            OrderDetails detail3 = new OrderDetails(egg, 20);
            OrderDetails detail4 = new OrderDetails(milk, 2);
            OrderDetails detail5 = new OrderDetails(milk, 5);
            order1.AddOrderDetail(detail1);
            order1.AddOrderDetail(detail3);
            order1.AddOrderDetail(detail4);
            order2.AddOrderDetail(detail2);
            order3.AddOrderDetail(detail3);
            order3.AddOrderDetail(detail5);
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            
            Console.WriteLine("GetAllOrders");
            List<Orders> orders = os.Orders;
            orders.ForEach(o => Console.WriteLine(o));
            Console.WriteLine("");
        }
    }
}
