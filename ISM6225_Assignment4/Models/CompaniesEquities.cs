using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ISM6225_Assignment4.Models.EF_Models;

namespace ISM6225_Assignment4.Models
{
    public class CompaniesEquities
    {
        public List<Symbol> Symbols { get; set; }
        public Equity Current { get; set; }
        public string Dates { get; set; }
        public string Prices { get; set; }
        public string Volumes { get; set; }
        public float AvgPrice { get; set; }
        public double AvgVolume { get; set; }

        public CompaniesEquities(List<Symbol> symbols, Equity current,
                                          string dates, string prices, string volumes,
                                          float avgprice, double avgvolume)
        {
            Symbols = symbols;
            Current = current;
            Dates = dates;
            Prices = prices;
            Volumes = volumes;
            AvgPrice = avgprice;
            AvgVolume = avgvolume;
        }
    }
}

