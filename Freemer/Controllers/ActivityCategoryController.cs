using Microsoft.AspNetCore.Mvc;
using Freemer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freemer.Controllers
{
    public class ActivityCategoryController : Controller
    {
        private readonly IActivityCategoryRepository _activityCategoryRepository;

        public ActivityCategoryController(IActivityCategoryRepository activityCategoryRepository)
        {
            _activityCategoryRepository = activityCategoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
