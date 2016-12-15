using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gateway.Models;

namespace EsbjergCityAdmin.Models
{
    public class PaginatedViewModel
    {
        public List<Event> Events { get; set; }
        public int Page { get; set; }
        public int ItemsPrPage { get; set; }
        public int TotalEvents { get; set; }
    }
}