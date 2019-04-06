﻿// <auto-generated />
using ISM6225_Assignment4.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ISM6225_Assignment4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ISM6225_Assignment4.Models.EF_Models+Company", b =>
                {
                    b.Property<string>("symbol")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CEO");

                    b.Property<string>("companyName");

                    b.Property<string>("description");

                    b.Property<string>("exchange");

                    b.Property<string>("industry");

                    b.Property<string>("issueType");

                    b.Property<string>("sector");

                    b.Property<string>("website");

                    b.HasKey("symbol");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ISM6225_Assignment4.Models.EF_Models+Equity", b =>
                {
                    b.Property<int>("EquityId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("change");

                    b.Property<float>("changeOverTime");

                    b.Property<float>("changePercent");

                    b.Property<float>("close");

                    b.Property<string>("date");

                    b.Property<float>("high");

                    b.Property<string>("label");

                    b.Property<float>("low");

                    b.Property<float>("open");

                    b.Property<string>("symbol");

                    b.Property<int>("unadjustedVolume");

                    b.Property<int>("volume");

                    b.Property<float>("vwap");

                    b.HasKey("EquityId");

                    b.ToTable("Equities");
                });

            modelBuilder.Entity("ISM6225_Assignment4.Models.EF_Models+KeyStats", b =>
                {
                    b.Property<int>("KeyStatsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EBITDA");

                    b.Property<int>("EPSSurpriseDollar");

                    b.Property<int>("EPSSurprisePercent");

                    b.Property<int>("beta");

                    b.Property<int>("cash");

                    b.Property<string>("companyName");

                    b.Property<int>("consensusEPS");

                    b.Property<int>("day200MovingAvg");

                    b.Property<int>("day5ChangePercent");

                    b.Property<int>("debt");

                    b.Property<int>("dividendRate");

                    b.Property<int>("dividendYield");

                    b.Property<string>("exDividendDate");

                    b.Property<int>("floatStat");

                    b.Property<int>("grossProfit");

                    b.Property<int>("insiderPercent");

                    b.Property<int>("institutionPercent");

                    b.Property<int>("latestEPS");

                    b.Property<string>("latestEPSDate");

                    b.Property<int>("marketCap");

                    b.Property<int>("month1ChangePercent");

                    b.Property<int>("month3ChangePercent");

                    b.Property<int>("month6ChangePercent");

                    b.Property<int>("numberofEstimates");

                    b.Property<int>("perRatioHigh");

                    b.Property<int>("perRatioLow");

                    b.Property<int>("priceToBook");

                    b.Property<int>("priceToSales");

                    b.Property<int>("profitMargin");

                    b.Property<int>("returnOnAssets");

                    b.Property<int>("returnOnEquity");

                    b.Property<int>("returnonCapital");

                    b.Property<int>("revenue");

                    b.Property<int>("revenuePerEmployee");

                    b.Property<int>("revenuePerShare");

                    b.Property<int>("sharesOutstanding");

                    b.Property<int>("shortInterest");

                    b.Property<int>("shortRatio");

                    b.Property<string>("shortdate");

                    b.Property<string>("symbol");

                    b.Property<int>("ttmEPS");

                    b.Property<int>("week52change");

                    b.Property<int>("week52high");

                    b.Property<int>("week52low");

                    b.Property<int>("year1ChangePercent");

                    b.Property<int>("year2ChangePercent");

                    b.Property<int>("year5ChangePercent");

                    b.Property<int>("ytdChangePercent");

                    b.HasKey("KeyStatsId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("ISM6225_Assignment4.Models.EF_Models+Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("avgTotalVolume");

                    b.Property<string>("calculationPrice");

                    b.Property<int>("change");

                    b.Property<int>("changePercent");

                    b.Property<int>("close");

                    b.Property<int>("closeType");

                    b.Property<string>("companyName");

                    b.Property<int>("delayedPrice");

                    b.Property<int>("delayedPriceTime");

                    b.Property<int>("extendedChange");

                    b.Property<int>("extendedChangePercent");

                    b.Property<int>("extendedPrice");

                    b.Property<int>("extendedPriceTime");

                    b.Property<int>("high");

                    b.Property<int>("iexAskPrice");

                    b.Property<int>("iexAskSize");

                    b.Property<int>("iexBidPrice");

                    b.Property<int>("iexBidSize");

                    b.Property<int>("iexLastUpdated");

                    b.Property<int>("iexMarketPercent");

                    b.Property<int>("iexRealtimePrice");

                    b.Property<int>("iexRealtimeSize");

                    b.Property<int>("iexVolume");

                    b.Property<int>("latestPrice");

                    b.Property<string>("latestSource");

                    b.Property<string>("latestTime");

                    b.Property<int>("latestUpdate");

                    b.Property<int>("latestVolume");

                    b.Property<int>("low");

                    b.Property<int>("marketCap");

                    b.Property<int>("open");

                    b.Property<int>("openType");

                    b.Property<int>("peRatio");

                    b.Property<string>("primaryExchange");

                    b.Property<string>("sector");

                    b.Property<string>("symbol");

                    b.Property<int>("week52High");

                    b.Property<int>("week52Low");

                    b.Property<int>("ytdChange");

                    b.HasKey("QuoteId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("ISM6225_Assignment4.Models.EF_Models+Symbol", b =>
                {
                    b.Property<string>("symbol")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("date");

                    b.Property<string>("iexId");

                    b.Property<bool>("isEnabled");

                    b.Property<string>("name");

                    b.Property<string>("type");

                    b.HasKey("symbol");

                    b.ToTable("Symbols");
                });
#pragma warning restore 612, 618
        }
    }
}
