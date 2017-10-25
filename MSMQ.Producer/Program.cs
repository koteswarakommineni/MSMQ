using MSMQ.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\OrdersQueue");
            OrderGenerator orderGenerator = new OrderGenerator();
            Random r = new Random(DateTime.Now.Millisecond);
            Console.Write("Press Y or Enter to place an order  or N to Exit. ");
            String choice = "";
            choice = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(choice) || String.Equals(choice, "n", StringComparison.OrdinalIgnoreCase))
            {
                orderGenerator
                    .GenerateOrders(r.Next(1,3))
                    .AsParallel()
                    .ForAll(a => 
                    {
                        Message m = new Message(a, MessageFormatters.OrderMessageFormatter);
                        Console.WriteLine("Placing Order...{0}", a.ToString());
                        messageQueue.Send(m);
                    });
                 Thread.Sleep(3000);
                Console.WriteLine("Press Y to place an order  or N to Exit. ");
                choice = Console.ReadLine();
                Console.WriteLine("Processing the request....");
            }
                
                
        }
    }
}
