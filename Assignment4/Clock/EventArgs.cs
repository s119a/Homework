using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class EventArgs
    {
        public string Message { get; set; }
        public EventArgs(string message)
        {
            Message = message;
        }
    }
}
