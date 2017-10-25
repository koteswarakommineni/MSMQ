using MSMQ.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MSMQ.Consumer
{
    class Program
    {
        private static MessageQueue messageQueue = new MessageQueue(@".\Private$\OrdersQueue");
        
       static void Main(string[] args)
        {
            Timer t = new Timer(5000);
            t.Elapsed += T_Elapsed;
            t.Start();
            Console.WriteLine("Starting to Monitor the Queue.");
            Console.ReadLine();
        }

        private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            Message m = null;
            while((m = messageQueue.Peek()) != null)
            {
                m = messageQueue.Receive();
                m.Formatter = MessageFormatters.OrderMessageFormatter;
                Console.WriteLine("Received Order...{0}", m.Body);
            }
        }
    }
}
