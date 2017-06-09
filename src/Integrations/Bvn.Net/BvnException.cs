using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bvn.Net
{
    public class BvnException : Exception
    {
        public BvnException(string message) : base(message)
        {
        }

        public BvnException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
