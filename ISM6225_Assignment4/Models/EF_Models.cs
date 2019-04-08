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
            public int open { get; set; }
            public int openType { get; set; }
            public int close { get; set; }
            public int closeType { get; set; }
            public int high { get; set; }
            public int low { get; set; }
            public int latestPrice { get; set; }
            public string latestSource { get; set; }
            public string latestTime { get; set; }
            public int latestUpdate { get; set; }
            public int latestVolume { get; set; }
            public int iexRealtimePrice { get; set; }
            public int iexRealtimeSize { get; set; }
            public int iexLastUpdated { get; set; }
            public int delayedPrice { get; set; }
            public int delayedPriceTime { get; set; }
            public int extendedPrice { get; set; }
            public int extendedChange { get; set; }
            public int extendedChangePercent { get; set; }
            public int extendedPriceTime { get; set; }
            public int change { get; set; }
            public int changePercent { get; set; }
            public int iexMarketPercent { get; set; }
            public int iexVolume { get; set; }
            public int avgTotalVolume { get; set; }
            public int iexBidPrice { get; set; }
            public int iexBidSize { get; set; }
            public int iexAskPrice { get; set; }
            public int iexAskSize { get; set; }
            public int marketCap { get; set; }
            public int peRatio { get; set; }
            public int week52High { get; set; }
            public int week52Low { get; set; }
            public int ytdChange { get; set; }
        }
    }
}
