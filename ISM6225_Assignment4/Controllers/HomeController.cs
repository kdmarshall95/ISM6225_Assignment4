using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISM6225_Assignment4.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ISM6225_Assignment4.Controllers
{
    public class HomeController : Controller
    {
        string BASE_URL = "https://api.iextrading.com/1.0/";
        HttpClient httpClient;

        public HomeController()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Symbol> GetSymbols()
        {
            string IEXTrading_API_PATH = BASE_URL + "ref-data/symbols";
            string companyList = "";
            List<Symbol> companies = null;

            // Connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // Read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                companyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // Parse the Json strings as C# objects
            if (!companyList.Equals(""))
            {
                companies = JsonConvert.DeserializeObject<List<Symbol>>(companyList);
            }

            return companies;
        }

        public IActionResult Index()
        {
            // Get the data from the List using GetSymbols method
            List<Symbol> companies = GetSymbols();
            // Send the data to the Index view
            return View(companies);
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
