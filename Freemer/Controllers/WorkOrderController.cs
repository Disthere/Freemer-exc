using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
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
        [HttpGet]
        public async Task<IActionResult> GetAllWorkOrders()
        {
            var response = await _workOrderRepository.Select();

            WorkOrder o1 = new()
            {
                Description = "Простой сайт",
                Title = "веб",
                FinalPrice = 1000,
                Relevance = OrderRelevance.Published,
                ActivityCategoryId = 2
            };

            await _workOrderRepository.Create(o1);

            var response1 = await _workOrderRepository.Get(2);

            var response2 = await _workOrderRepository.GetByActivityCategoryId(1);

            var response3 = await _workOrderRepository.GetByTitle("веб");


            return View(response);
        }
    }
}
