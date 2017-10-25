using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ.Messages
{
    public static class MessageFormatters
    {
        public static IMessageFormatter OrderMessageFormatter = new XmlMessageFormatter(new Type[] { typeof(Order) });
    }
}
