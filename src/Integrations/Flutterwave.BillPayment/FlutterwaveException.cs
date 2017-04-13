using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.BillPayment
{
    public class FlutterwaveException : Exception
    {
        public FlutterwaveException(string message) : base(message)
        {
        }

        public FlutterwaveException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
