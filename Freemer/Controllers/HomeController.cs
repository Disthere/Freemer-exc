using Freemer.DAL;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
using Freemer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Freemer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            {
                JobCategory a1 = new() { Name = "C#" };
                JobCategory a2 = new() { Name = "F#" };
                JobCategory a3 = new() { Name = "C# - EF Core", ParentId = 1 };

                Order o1 = new()
                {
                    Description = "ВПФ приложение",
                    Title = "app",
                    FinalPrice = 1200,
                    Relevance = OrderRelevance.Published,
                    JobCategoryId = 1
                };

                Order o2 = new()
                {
                    Description = "Ф приложение",
                    Title = "app F",
                    FinalPrice = 5200,
                    Relevance = OrderRelevance.WorkerIsSelected,
                    JobCategoryId = 2
                };

                using (_dbContext)
                {
                    _dbContext.JobCategory.AddRange(new List<JobCategory> { a1, a2, a3 });
                    _dbContext.Order.AddRange(new List<Order> { o1, o2 });

                    _dbContext.SaveChanges();
                }
            }

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
