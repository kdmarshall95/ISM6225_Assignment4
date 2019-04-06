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
        public class Chart
        {
            public string minute{get;set;}
            public int marketAverage{get;set;}
            public int marketNotional{get;set;}
            public int marketNumberOfTrades{get;set;}
            public int marketOpen{get;set;}
            public int marketClose{get;set;}
            public int marketHigh{get;set;}
            public int marketLow{get;set;}
            public int Volume{get;set;}
            public int marketChangeOverTime{get;set;}
            public int average{get;set;}
            public int notional{get;set;}
            public int numberOfTrades{get;set;}
            /*public int simplifyFactor{get;set;}*/
            public int high{get;set;}
            public int low{get;set;}
            public int volume{get;set;}
            public int label{get;set;}
            public int changeOverTime{get;set;}
            public string date{get;set;}
            public int open{get;set;}
            public int close{get;set;}
            public int unadjustedVolume{get;set;}
            public int change{get;set;}
            public int changePercent{get;set;}
            public int vwap{get;set;}
        }
        public class Company
        {
            public string symbol{get;set;}
            public string companyName{get;set;}
            public string excahnge{get;set;}
            public string industry{get;set;}
            public string website{get;set;}
            public string description{get;set;}
            public string CEO{get;set;}
            public string issueType{get;set;}
            public string sector{get;set;}
            public list<string> tags{get;set;}
        }
    }
}
