using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Configuration.Paylink
{
    public class Charges
    {
        public decimal Flat { get; set; }
        public decimal FromWallet { get; set; }
        public decimal FromCard { get; set; }
        public decimal FromBank { get; set; }
        public decimal WalletWithdrawalRate { get; set; }
    }
}
