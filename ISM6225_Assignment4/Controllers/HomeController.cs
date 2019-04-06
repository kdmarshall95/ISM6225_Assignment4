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


        public IActionResult Index()
        {
            // Get the data from the List using GetSymbols method
            List<Symbol> symbols = GetSymbols();
            // Send the data to the Index view
            return View(symbols);
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
