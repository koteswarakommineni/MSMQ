using MSMQ.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ.Producer
{
    public class OrderGenerator
    {
        List<String> products = new List<string>() { "Product A", "Product B", "Product C", "Product D", "Product E", "Product F", "Product G", "Product H", "Product I", "Product J", "Product K", "Product L", "Product M", "Product N", "Product O", "Product P", "Product Q", "Product R", "Product S", "Product T", "Product U", "Product V", "Product W", "Product X", "Product Y", "Product Z" };
        public List<Order> GenerateOrders(int n = 10)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            
            List<Order> orders = new List<Order>();
            for (int i = 0; i < n; i++)
            {
                orders.Add(new Order() { Id = DateTime.Now.ToString("hhMMddHHmmssffffff"), Product = "Product " + products[r.Next(0, products.Count - 1)], Quantity = r.Next(1, 100) });
            }

            return orders;
        }
    }
}
