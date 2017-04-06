using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.BillPayment
{
    public class BillPaymentException : Exception
    {
        public BillPaymentException(string message) : base(message)
        {
        }

        public BillPaymentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
