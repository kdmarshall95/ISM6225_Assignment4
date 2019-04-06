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
            public int marketCap { get; set; }
            public int beta { get; set; }
            public int week52high { get; set; }
            public int week52low { get; set; }
            public int week52change { get; set; }
            public int shortInterest { get; set; }
            public string shortdate { get; set; }
            public int dividendRate { get; set; }
            public int dividendYield { get; set; }
            public string exDividendDate { get; set; }
            public int latestEPS { get; set; }
            public string latestEPSDate { get; set; }
            public int sharesOutstanding { get; set; }
            public int floatStat { get; set; }
            public int returnOnEquity { get; set; }
            public int consensusEPS { get; set; }
            public int numberofEstimates { get; set; }
            public string symbol { get; set; }
            public int EBITDA { get; set; }
            public int revenue { get; set; }
            public int grossProfit { get; set; }
            public int cash { get; set; }
            public int debt { get; set; }
            public int ttmEPS { get; set; }
            public int revenuePerShare { get; set; }
            public int revenuePerEmployee { get; set; }
            public int perRatioHigh { get; set; }
            public int perRatioLow { get; set; }
            public int EPSSurpriseDollar { get; set; }
            public int EPSSurprisePercent { get; set; }
            public int returnOnAssets { get; set; }
            public int returnonCapital { get; set; }
            public int profitMargin { get; set; }
            public int priceToSales { get; set; }
            public int priceToBook { get; set; }
            public int day200MovingAvg { get; set; }
            public int institutionPercent { get; set; }
            public int insiderPercent { get; set; }
            public int shortRatio { get; set; }
            public int year5ChangePercent { get; set; }
            public int year2ChangePercent { get; set; }
            public int year1ChangePercent { get; set; }
            public int ytdChangePercent { get; set; }
            public int month6ChangePercent { get; set; }
            public int month3ChangePercent { get; set; }
            public int month1ChangePercent { get; set; }
            public int day5ChangePercent { get; set; }
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
