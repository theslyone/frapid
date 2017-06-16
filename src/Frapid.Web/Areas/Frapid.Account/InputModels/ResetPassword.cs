using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frapid.Account.InputModels
{
    public class ResetPassword
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}