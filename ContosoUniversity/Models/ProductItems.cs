using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class ProductItems {
        public int total { get; set; }
        
        public string items { get; set; }

        public string facets { get; set; }

        public string corrections { get; set; }

        public string locale { get; set; }

        public string volatility { get; set; }

        public int code { get; set; }

        public string warnings { get; set; }
    }
}