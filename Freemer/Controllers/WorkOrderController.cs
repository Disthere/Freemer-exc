using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freemer.Controllers
{
    public class WorkOrderController : Controller
    {
        //private readonly IWorkOrderRepository _workOrderRepository;

        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workOrderService) => (_workOrderService) = (workOrderService);


        //public WorkOrderController(IWorkOrderRepository workOrderRepository)
        //{
        //    _workOrderRepository = workOrderRepository;

        //}
        [HttpGet]
        public async Task<IActionResult> GetAllWorkOrders()
        {
            var response = await _workOrderService.GetAllWorkOrders();

            WorkOrder o1 = new()
            {
                Description = "Простой сайт",
                Title = "веб",
                FinalPrice = 1000,
                Relevance = WorkOrderRelevance.Published,
                ActivityCategoryId = 2
            };

            //await _workOrderRepository.Create(o1);

            //var response1 = await _workOrderRepository.Get(2);

            //var response2 = await _workOrderRepository.GetByActivityCategoryId(1);

            //var response3 = await _workOrderRepository.GetByTitle("веб");

            if (response.StatusCode == Domain.Enums.RequestToDbErrorStatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
