using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
using Freemer.Domain.ViewModels.WorkOrder;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freemer.Controllers
{
    public class OrderController : Controller
    {
        //private readonly IWorkOrderRepository _workOrderRepository;

        private readonly IWorkOrderService _workOrderService;

        public OrderController(IWorkOrderService workOrderService) => (_workOrderService) = (workOrderService);


        //public WorkOrderController(IWorkOrderRepository workOrderRepository)
        //{
        //    _workOrderRepository = workOrderRepository;

        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            WorkOrder o1 = new()
            {
                Description = "Большой сайт",
                Title = "веб",
                FinalPrice = 1000,
                Relevance = WorkOrderRelevance.RemovedByEmployer,
                ActivityCategoryId = 2
            };

            await _workOrderService.Update(7, o1);

            //await _workOrderService.Delete(4);

            var response = await _workOrderService.GetAllWorkOrders();

            var response1 = await _workOrderService.GetById(2);

            var response2 = await _workOrderService.GetByActivityCategoryId(2);

            var response3 = await _workOrderService.GetByTitle("веб");

            var response4 = await _workOrderService.GetByRelevance(2);

            if (response.StatusCode == Domain.Enums.RequestToDbErrorStatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }


    }
}
