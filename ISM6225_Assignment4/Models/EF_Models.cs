using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISM6225_Assignment4.Models
{
    public class Symbol
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public bool isEnabled { get; set; }
        public string type { get; set; }
        public string iexId { get; set; }
    }
}
