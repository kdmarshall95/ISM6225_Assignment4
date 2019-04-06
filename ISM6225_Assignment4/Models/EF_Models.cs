using System.ComponentModel.DataAnnotations;

namespace ISM6225_Assignment4.Models
{
    public class EF_Models
    {
        public class Symbol
        {
            [Key]
            public string symbol { get; set; }
            public string name { get; set; }
            public string date { get; set; }
            public bool isEnabled { get; set; }
            public string type { get; set; }
            public string iexId { get; set; }
        }
    }
}
