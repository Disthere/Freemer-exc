using Microsoft.AspNetCore.Mvc;
using Freemer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freemer.Controllers
{
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public JobCategoryController(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
