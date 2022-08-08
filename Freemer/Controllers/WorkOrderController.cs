using Freemer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freemer.Controllers
{
    public class WorkOrderController : Controller
    {
        private readonly IWorkOrderRepository _workOrderRepository;

        public WorkOrderController(IWorkOrderRepository workOrderRepository)
        {
            _workOrderRepository = workOrderRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
