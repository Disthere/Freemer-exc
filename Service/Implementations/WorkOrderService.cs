using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
using Freemer.Domain.Response;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    class WorkOrderService : IWorkOrderService
    {
        private readonly IWorkOrderRepository _workOrderRepository;

        public WorkOrderService(IWorkOrderRepository workOrderRepository) => (_workOrderRepository) = (workOrderRepository);
        
        public async Task<IBaseResponse<IEnumerable<WorkOrder>>> GetAllWorkOrders()
        {
            var baseResponse = new BaseResponse<IEnumerable<WorkOrder>>();

            try
            {
                var workOrders = await _workOrderRepository.Select();
                if (workOrders.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.Ok;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WorkOrder>>()
                {
                    Description = $"[GetAllWorkOrders] : {ex.Message}"
                };
            }
        }
    }
}
