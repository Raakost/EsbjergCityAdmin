using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public class Order : AbstractId
    {
        [Display(Name = "Købstidspunkt")]
        public DateTime DateOfPurchase { get; set; }
        public List<GiftCard> GiftCards { get; set; }

        [Display(Name = "Accepteret")]
        public bool IsCompleted { get; set; }
    }
}
