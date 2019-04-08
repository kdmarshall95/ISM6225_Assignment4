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
                    EBITDA = table.Column<long>(nullable: true),
                    EPSSurpriseDollar = table.Column<float>(nullable: true),
                    EPSSurprisePercent = table.Column<float>(nullable: true),
                    beta = table.Column<float>(nullable: true),
                    cash = table.Column<long>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    consensusEPS = table.Column<float>(nullable: true),
                    day200MovingAvg = table.Column<float>(nullable: true),
                    day5ChangePercent = table.Column<float>(nullable: true),
                    debt = table.Column<long>(nullable: true),
                    dividendRate = table.Column<float>(nullable: true),
                    dividendYield = table.Column<float>(nullable: true),
                    exDividendDate = table.Column<string>(nullable: true),
                    floatStat = table.Column<long>(nullable: true),
                    grossProfit = table.Column<long>(nullable: true),
                    insiderPercent = table.Column<float>(nullable: true),
                    institutionPercent = table.Column<float>(nullable: true),
                    latestEPS = table.Column<float>(nullable: true),
                    latestEPSDate = table.Column<string>(nullable: true),
                    marketCap = table.Column<long>(nullable: true),
                    month1ChangePercent = table.Column<float>(nullable: true),
                    month3ChangePercent = table.Column<float>(nullable: true),
                    month6ChangePercent = table.Column<float>(nullable: true),
                    numberofEstimates = table.Column<int>(nullable: true),
                    perRatioHigh = table.Column<float>(nullable: true),
                    perRatioLow = table.Column<float>(nullable: true),
                    priceToBook = table.Column<float>(nullable: true),
                    priceToSales = table.Column<float>(nullable: true),
                    profitMargin = table.Column<float>(nullable: true),
                    returnOnAssets = table.Column<float>(nullable: true),
                    returnOnEquity = table.Column<float>(nullable: true),
                    returnonCapital = table.Column<float>(nullable: true),
                    revenue = table.Column<long>(nullable: true),
                    revenuePerEmployee = table.Column<float>(nullable: true),
                    revenuePerShare = table.Column<float>(nullable: true),
                    sharesOutstanding = table.Column<long>(nullable: true),
                    shortInterest = table.Column<int>(nullable: true),
                    shortRatio = table.Column<float>(nullable: true),
                    shortdate = table.Column<string>(nullable: true),
                    symbol = table.Column<string>(nullable: true),
                    ttmEPS = table.Column<float>(nullable: true),
                    week52change = table.Column<float>(nullable: true),
                    week52high = table.Column<float>(nullable: true),
                    week52low = table.Column<float>(nullable: true),
                    year1ChangePercent = table.Column<float>(nullable: true),
                    year2ChangePercent = table.Column<float>(nullable: true),
                    year5ChangePercent = table.Column<float>(nullable: true),
                    ytdChangePercent = table.Column<float>(nullable: true)
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
