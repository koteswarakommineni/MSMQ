using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ.Messages
{
    public class Order
    {
        public String Id { get; set; }
        public String Product { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", Id, Product, Quantity);
        }
    }
}
