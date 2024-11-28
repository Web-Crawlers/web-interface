using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebCrawlerInterface.Models;

namespace WebCrawlerInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var responses = new List<string>();
            IMongoCollection<Articles> _articlesCollection;

            try
            {
                var mongoClient = new MongoClient("mongodb://10.96.0.101:27017");

                var mongoDatabase = mongoClient.GetDatabase("mydb");

                _articlesCollection = mongoDatabase.GetCollection<Articles>("Articles");

                ViewData["data"] = _articlesCollection.Find(_ => true).ToList();
            }
            catch (Exception e)
            {
                responses.Add(e.Message);
            }

            ViewData["response"] = responses;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
