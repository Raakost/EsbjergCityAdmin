using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public class Customer : AbstractId
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public List<Order> Orders { get; set; }
    }
}
