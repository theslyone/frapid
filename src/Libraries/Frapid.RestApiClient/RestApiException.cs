using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.RestApi
{
    public class RestApiException : Exception
    {
        public RestApiException(string message) : base(message)
        {
        }

        public RestApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
