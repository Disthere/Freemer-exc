using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
using Freemer.Domain.ViewModels.Order;
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

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => (_orderService) = (orderService);


        //public WorkOrderController(IWorkOrderRepository workOrderRepository)
        //{
        //    _workOrderRepository = workOrderRepository;

        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            Order o1 = new()
            {
                Description = "Большой сайт",
                Title = "веб",
                FinalPrice = 1000,
                Relevance = OrderRelevance.RemovedByEmployer,
                JobCategoryId = 2
            };

            await _orderService.Update(7, o1);

            //await _workOrderService.Delete(4);

            var response = await _orderService.GetAllOrders();

            var response1 = await _orderService.GetById(2);

            var response2 = await _orderService.GetByJobCategoryId(2);

            var response3 = await _orderService.GetByTitle("веб");

            var response4 = await _orderService.GetByRelevance(2);

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
