using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net
{
    public class MoneywaveException : Exception
    {
        public MoneywaveException(string message) : base(message)
        {
        }

        public MoneywaveException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
