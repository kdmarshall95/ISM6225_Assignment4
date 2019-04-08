using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static ISM6225_Assignment4.Models.EF_Models;
using ISM6225_Assignment4.Models;
using ISM6225_Assignment4.DataAccess;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace ISM6225_Assignment4.Controllers
{
    public class HomeController : Controller
    {
        /*
            These lines are needed to use the Database context,
            define the connection to the API, and use the
            HttpClient to request data from the API
        */
        public ApplicationDbContext dbContext;
        //Base URL for the IEXTrading API. Method specific URLs are appended to this base URL.
        string BASE_URL = "https://api.iextrading.com/1.0/";
        HttpClient httpClient;

        /*
             These lines create a Constructor for the HomeController.
             Then, the Database context is defined in a variable.
             Then, an instance of the HttpClient is created.

        */

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Symbol> GetSymbols()
        {
            string IEXTrading_API_PATH = BASE_URL + "ref-data/symbols";
            string symbolList = "";
            List<Symbol> symbols = null;

            // connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                symbolList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // now, parse the Json strings as C# objects
            if (!symbolList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                symbols = JsonConvert.DeserializeObject<List<Symbol>>(symbolList);
                symbols = symbols.GetRange(0, 50);
            }

            return symbols;
        }

        public List<KeyStats> GetOurPicks()
        {
            List<Symbol> symbols = GetSymbols();
            List<KeyStats> statsList = new List<KeyStats>();
            //PopulateSymbols();

            foreach (Symbol s in symbols)
            {
                statsList.Add(GetKeyStats(s.symbol));
                PopulateStats();
            }

            var ourList = from ks in statsList
                      where ks.evEBITDA <= 8 && ks.returnOnEquity >= 0.18 && ks.returnonCapital >= 0.12
                      select ks;

            return ourList.ToList();
        }

        /*
            The Symbols action calls the GetSymbols method that returns a list of Companies.
            This list of Companies is passed to the Symbols View.
        */
        public IActionResult Symbols()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<Symbol> symbols = GetSymbols();

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["Symbols"] = JsonConvert.SerializeObject(symbols);

            return View(symbols);
        }

        /*
            Save the available symbols in the database
        */
        public IActionResult PopulateSymbols()
        {
            // Retrieve the companies that were saved in the symbols method
            List<Symbol> symbols = JsonConvert.DeserializeObject<List<Symbol>>(TempData["Symbols"].ToString());

            foreach (Symbol symbol in symbols)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Symbols.Where(s => s.symbol.Equals(symbol.symbol)).Count() == 0)
                {
                    dbContext.Symbols.Add(symbol);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", symbols);
        }

        public List<Equity> GetChart(string symbol)
        {
            // string to specify information to be retrieved from the API
            string IEXTrading_API_PATH = BASE_URL + "stock/" + symbol + "/batch?types=chart&range=1y";

            // initialize objects needed to gather data
            string charts = "";
            List<Equity> Equities = new List<Equity>();
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);

            // connect to the API and obtain the response
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // now, obtain the Json objects in the response as a string
            if (response.IsSuccessStatusCode)
            {
                charts = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // parse the string into appropriate objects
            if (!charts.Equals(""))
            {
                ChartRoot root = JsonConvert.DeserializeObject<ChartRoot>(charts,
                  new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                Equities = root.chart.ToList();
            }

            // fix the relations. By default the quotes do not have the company symbol
            //  this symbol serves as the foreign key in the database and connects the quote to the company
            foreach (Equity Equity in Equities)
            {
                Equity.symbol = symbol;
            }

            return Equities;
        }

        public Company GetCompany(string symbol)
        {
            string IEXTrading_API_PATH = BASE_URL + "stock/" + symbol + "/company";
            string companyList = "";
            Company company = null;

            // connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                companyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // now, parse the Json strings as C# objects
            if (!companyList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                company = JsonConvert.DeserializeObject<Company>(companyList);
            }

            return company;
        }

        /*
            The Symbols action calls the GetSymbols method that returns a list of Companies.
            This list of Companies is passed to the Symbols View.
        */
        public IActionResult Companies(string symbol)
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            Company companies = GetCompany(symbol);

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["Companies"] = JsonConvert.SerializeObject(companies);

            return View(companies);
        }

        /*
            Save the available symbols in the database
        */
        public IActionResult PopulateCompanies()
        {
            // Retrieve the companies that were saved in the symbols method
            List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(TempData["Companies"].ToString());

            foreach (Company company in companies)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Companies.Where(c => c.symbol.Equals(company.symbol)).Count() == 0)
                {
                    dbContext.Companies.Add(company);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", companies);
        }

        public KeyStats GetKeyStats(string symbol)
        {
            string IEXTrading_API_PATH = BASE_URL + "stock/" + symbol + "/stats";
            string kstatsList = "";
            KeyStats stats = null;

            // connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                kstatsList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // now, parse the Json strings as C# objects
            if (!kstatsList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                stats = JsonConvert.DeserializeObject<KeyStats>(kstatsList);
            }
            if (stats.marketCap != null && stats.evEBITDA != null)
            {
                stats.evEBITDA = stats.marketCap / stats.EBITDA;
            }

            return stats;
        }

        /*
            The Symbols action calls the GetSymbols method that returns a list of Companies.
            This list of Companies is passed to the Symbols View.
        */
        public IActionResult KeyStats(string symbol)
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            KeyStats stats = GetKeyStats(symbol);

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["Stats"] = JsonConvert.SerializeObject(stats);

            return View(stats);
        }

        /*
            Save the available symbols in the database
        */
        public IActionResult PopulateStats()
        {
            // Retrieve the companies that were saved in the symbols method
            List<KeyStats> stats = JsonConvert.DeserializeObject<List<KeyStats>>(TempData["Stats"].ToString());

            foreach (KeyStats keyStats in stats)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Stats.Where(ks => ks.KeyStatsId.Equals(keyStats.KeyStatsId)).Count() == 0)
                {
                    dbContext.Stats.Add(keyStats);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", stats);
        }

        public Quote GetQuotes(string symbol)
        {
            string IEXTrading_API_PATH = BASE_URL + "stock/" + symbol + "/quote";
            string quoteList = "";
            Quote quotes = null;

            // connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                quoteList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // now, parse the Json strings as C# objects
            if (!quoteList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                quotes = JsonConvert.DeserializeObject<Quote>(quoteList);
            }

            return quotes;
        }

        /*
            The Symbols action calls the GetSymbols method that returns a list of Companies.
            This list of Companies is passed to the Symbols View.
        */
        public IActionResult Quotes(string symbol)
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            Quote quotes = GetQuotes(symbol);

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["Quotes"] = JsonConvert.SerializeObject(quotes);

            return View(quotes);
        }

        /*
            Save the available symbols in the database
        */
        public IActionResult PopulateQuotes()
        {
            // Retrieve the companies that were saved in the symbols method
            List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(TempData["Quotes"].ToString());

            foreach (Quote quote in quotes)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Quotes.Where(q => q.QuoteId.Equals(quote.QuoteId)).Count() == 0)
                {
                    dbContext.Quotes.Add(quote);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", quotes);
        }

        public IActionResult SaveCharts(string symbol)
        {
            List<Equity> equities = GetChart(symbol);

            // save the quote if the quote has not already been saved in the database
            foreach (Equity equity in equities)
            {
                if (dbContext.Equities.Where(c => c.date.Equals(equity.date)).Count() == 0)
                {
                    dbContext.Equities.Add(equity);
                }
            }

            // persist the data
            dbContext.SaveChanges();

            // populate the models to render in the view
            ViewBag.dbSuccessChart = 1;
            CompaniesEquities companiesEquities = getCompaniesEquitiesModel(equities);
            return View("Chart", companiesEquities);
        }

        public CompaniesEquities getCompaniesEquitiesModel(List<Equity> equities)
        {
            List<Symbol> symbols = dbContext.Symbols.ToList();

            if (equities.Count == 0)
            {
                return new CompaniesEquities(symbols, null, "", "", "", 0, 0);
            }

            Equity current = equities.Last();

            // create appropriately formatted strings for use by chart.js
            string dates = string.Join(",", equities.Select(e => e.date));
            string prices = string.Join(",", equities.Select(e => e.high));
            float avgprice = equities.Average(e => e.high);

            //Divide volumes by million to scale appropriately
            string volumes = string.Join(",", equities.Select(e => e.volume / 1000000));
            double avgvol = equities.Average(e => e.volume) / 1000000;

            return new CompaniesEquities(symbols, equities.Last(), dates, prices, volumes, avgprice, avgvol);
        }

        // ******************************************************************************************************************//


        public IActionResult Index()
        {
            ViewBag.dbSuccessComp = 0;
            List<KeyStats> ourPicks = GetOurPicks();

            TempData["OurPicks"] = JsonConvert.SerializeObject(ourPicks);

            return View("OurPicks", ourPicks);
        }

        public IActionResult OurPicks()
        {
            ViewBag.dbSuccessComp = 0;
            List<KeyStats> ourPicks = GetOurPicks();

            TempData["OurPicks"] = JsonConvert.SerializeObject(ourPicks);

            return View(ourPicks);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
