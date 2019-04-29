using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public class Company
        {
            [Key]
            public string symbol { get; set; }
            public string companyName { get; set; }
            public string exchange { get; set; }
            public string industry { get; set; }
            public string website { get; set; }
            public string description { get; set; }
            public string CEO { get; set; }
            public string issueType { get; set; }
            public string sector { get; set; }
            [NotMapped]
            public string[] tags { get; set; }
        }

        public class Equity
        {
            public int EquityId { get; set; }
            public string date { get; set; }
            public float open { get; set; }
            public float high { get; set; }
            public float low { get; set; }
            public float close { get; set; }
            public int volume { get; set; }
            public int unadjustedVolume { get; set; }
            public float change { get; set; }
            public float changePercent { get; set; }
            public float vwap { get; set; }
            public string label { get; set; }
            public float changeOverTime { get; set; }
            public string symbol { get; set; }
        }

        public class ChartRoot
        {
            public Equity[] chart { get; set; }
        }

        public class KeyStats
        {
            public int KeyStatsId { get; set; }
            public string companyName { get; set; }
            public long? marketCap { get; set; }
            public float? beta { get; set; }
            public float? week52high { get; set; }
            public float? week52low { get; set; }
            public float? week52change { get; set; }
            public int? shortInterest { get; set; }
            public string shortdate { get; set; }
            public float? dividendRate { get; set; }
            public float? dividendYield { get; set; }
            public string exDividendDate { get; set; }
            public float? latestEPS { get; set; }
            public string latestEPSDate { get; set; }
            public long? sharesOutstanding { get; set; }
            public long? floatStat { get; set; }
            public float? returnOnEquity { get; set; }
            public float? consensusEPS { get; set; }
            public int? numberofEstimates { get; set; }
            public string symbol { get; set; }
            public long? EBITDA { get; set; }
            public long? revenue { get; set; }
            public long? grossProfit { get; set; }
            public long? cash { get; set; }
            public long? debt { get; set; }
            public float? ttmEPS { get; set; }
            public float? revenuePerShare { get; set; }
            public float? revenuePerEmployee { get; set; }
            public float? perRatioHigh { get; set; }
            public float? perRatioLow { get; set; }
            public float? EPSSurpriseDollar { get; set; }
            public float? EPSSurprisePercent { get; set; }
            public float? returnOnAssets { get; set; }
            public float? returnonCapital { get; set; }
            public float? profitMargin { get; set; }
            public float? priceToSales { get; set; }
            public float? priceToBook { get; set; }
            public float? day200MovingAvg { get; set; }
            public float? institutionPercent { get; set; }
            public float? insiderPercent { get; set; }
            public float? shortRatio { get; set; }
            public float? year5ChangePercent { get; set; }
            public float? year2ChangePercent { get; set; }
            public float? year1ChangePercent { get; set; }
            public float? ytdChangePercent { get; set; }
            public float? month6ChangePercent { get; set; }
            public float? month3ChangePercent { get; set; }
            public float? month1ChangePercent { get; set; }
            public float? day5ChangePercent { get; set; }
        }

        public class Quote
        {
            public int QuoteId { get; set; }
            public string symbol { get; set; }
            public string companyName { get; set; }
            public string primaryExchange { get; set; }
            public string sector { get; set; }
            public string calculationPrice { get; set; }
            public float? open { get; set; }
            public long? openTime { get; set; }
            public float? close { get; set; }
            public long? closeTime { get; set; }
            public float? high { get; set; }
            public float? low { get; set; }
            public float? latestPrice { get; set; }
            public string latestSource { get; set; }
            public string latestTime { get; set; }
            public long? latestUpdate { get; set; }
            public long? latestVolume { get; set; }
            public float? iexRealtimePrice { get; set; }
            public int? iexRealtimeSize { get; set; }
            public long? iexLastUpdated { get; set; }
            public float? delayedPrice { get; set; }
            public long? delayedPriceTime { get; set; }
            public float? extendedPrice { get; set; }
            public float? extendedChange { get; set; }
            public float? extendedChangePercent { get; set; }
            public long? extendedPriceTime { get; set; }
            public float? previousClose { get; set; }
            public float? change { get; set; }
            public float? changePercent { get; set; }
            public float? iexMarketPercent { get; set; }
            public int? iexVolume { get; set; }
            public long? avgTotalVolume { get; set; }
            public float? iexBidPrice { get; set; }
            public int? iexBidSize { get; set; }
            public float? iexAskPrice { get; set; }
            public int? iexAskSize { get; set; }
            public long? marketCap { get; set; }
            public float? peRatio { get; set; }
            public float? week52High { get; set; }
            public float? week52Low { get; set; }
            public float? ytdChange { get; set; }
        }

        public class News
        {
            public string datetime { get; set; }
            public string headline { get; set; }
            public string source { get; set; }
            public string url { get; set; }
            public string summary { get; set; }
            [NotMapped]
            public string related { get; set; }
            public string image { get; set; }
        }
    }
}
