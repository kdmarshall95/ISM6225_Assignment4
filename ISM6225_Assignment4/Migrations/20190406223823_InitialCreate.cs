using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISM6225_Assignment4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    CEO = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    exchange = table.Column<string>(nullable: true),
                    industry = table.Column<string>(nullable: true),
                    issueType = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "Equities",
                columns: table => new
                {
                    EquityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    change = table.Column<float>(nullable: false),
                    changeOverTime = table.Column<float>(nullable: false),
                    changePercent = table.Column<float>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    high = table.Column<float>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    low = table.Column<float>(nullable: false),
                    open = table.Column<float>(nullable: false),
                    symbol = table.Column<string>(nullable: true),
                    unadjustedVolume = table.Column<int>(nullable: false),
                    volume = table.Column<int>(nullable: false),
                    vwap = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equities", x => x.EquityId);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    avgTotalVolume = table.Column<int>(nullable: false),
                    calculationPrice = table.Column<string>(nullable: true),
                    change = table.Column<int>(nullable: false),
                    changePercent = table.Column<int>(nullable: false),
                    close = table.Column<int>(nullable: false),
                    closeType = table.Column<int>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    delayedPrice = table.Column<int>(nullable: false),
                    delayedPriceTime = table.Column<int>(nullable: false),
                    extendedChange = table.Column<int>(nullable: false),
                    extendedChangePercent = table.Column<int>(nullable: false),
                    extendedPrice = table.Column<int>(nullable: false),
                    extendedPriceTime = table.Column<int>(nullable: false),
                    high = table.Column<int>(nullable: false),
                    iexAskPrice = table.Column<int>(nullable: false),
                    iexAskSize = table.Column<int>(nullable: false),
                    iexBidPrice = table.Column<int>(nullable: false),
                    iexBidSize = table.Column<int>(nullable: false),
                    iexLastUpdated = table.Column<int>(nullable: false),
                    iexMarketPercent = table.Column<int>(nullable: false),
                    iexRealtimePrice = table.Column<int>(nullable: false),
                    iexRealtimeSize = table.Column<int>(nullable: false),
                    iexVolume = table.Column<int>(nullable: false),
                    latestPrice = table.Column<int>(nullable: false),
                    latestSource = table.Column<string>(nullable: true),
                    latestTime = table.Column<string>(nullable: true),
                    latestUpdate = table.Column<int>(nullable: false),
                    latestVolume = table.Column<int>(nullable: false),
                    low = table.Column<int>(nullable: false),
                    marketCap = table.Column<int>(nullable: false),
                    open = table.Column<int>(nullable: false),
                    openType = table.Column<int>(nullable: false),
                    peRatio = table.Column<int>(nullable: false),
                    primaryExchange = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    symbol = table.Column<string>(nullable: true),
                    week52High = table.Column<int>(nullable: false),
                    week52Low = table.Column<int>(nullable: false),
                    ytdChange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    KeyStatsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EBITDA = table.Column<int>(nullable: false),
                    EPSSurpriseDollar = table.Column<int>(nullable: false),
                    EPSSurprisePercent = table.Column<int>(nullable: false),
                    beta = table.Column<int>(nullable: false),
                    cash = table.Column<int>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    consensusEPS = table.Column<int>(nullable: false),
                    day200MovingAvg = table.Column<int>(nullable: false),
                    day5ChangePercent = table.Column<int>(nullable: false),
                    debt = table.Column<int>(nullable: false),
                    dividendRate = table.Column<int>(nullable: false),
                    dividendYield = table.Column<int>(nullable: false),
                    exDividendDate = table.Column<string>(nullable: true),
                    floatStat = table.Column<int>(nullable: false),
                    grossProfit = table.Column<int>(nullable: false),
                    insiderPercent = table.Column<int>(nullable: false),
                    institutionPercent = table.Column<int>(nullable: false),
                    latestEPS = table.Column<int>(nullable: false),
                    latestEPSDate = table.Column<string>(nullable: true),
                    marketCap = table.Column<int>(nullable: false),
                    month1ChangePercent = table.Column<int>(nullable: false),
                    month3ChangePercent = table.Column<int>(nullable: false),
                    month6ChangePercent = table.Column<int>(nullable: false),
                    numberofEstimates = table.Column<int>(nullable: false),
                    perRatioHigh = table.Column<int>(nullable: false),
                    perRatioLow = table.Column<int>(nullable: false),
                    priceToBook = table.Column<int>(nullable: false),
                    priceToSales = table.Column<int>(nullable: false),
                    profitMargin = table.Column<int>(nullable: false),
                    returnOnAssets = table.Column<int>(nullable: false),
                    returnOnEquity = table.Column<int>(nullable: false),
                    returnonCapital = table.Column<int>(nullable: false),
                    revenue = table.Column<int>(nullable: false),
                    revenuePerEmployee = table.Column<int>(nullable: false),
                    revenuePerShare = table.Column<int>(nullable: false),
                    sharesOutstanding = table.Column<int>(nullable: false),
                    shortInterest = table.Column<int>(nullable: false),
                    shortRatio = table.Column<int>(nullable: false),
                    shortdate = table.Column<string>(nullable: true),
                    symbol = table.Column<string>(nullable: true),
                    ttmEPS = table.Column<int>(nullable: false),
                    week52change = table.Column<int>(nullable: false),
                    week52high = table.Column<int>(nullable: false),
                    week52low = table.Column<int>(nullable: false),
                    year1ChangePercent = table.Column<int>(nullable: false),
                    year2ChangePercent = table.Column<int>(nullable: false),
                    year5ChangePercent = table.Column<int>(nullable: false),
                    ytdChangePercent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.KeyStatsId);
                });

            migrationBuilder.CreateTable(
                name: "Symbols",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    iexId = table.Column<string>(nullable: true),
                    isEnabled = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbols", x => x.symbol);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Equities");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Symbols");
        }
    }
}
