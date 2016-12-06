using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public class GiftCard : AbstractId
    {
        public string CardNumber { get; set; }
        public double Amount { get; set; }
    }
}
