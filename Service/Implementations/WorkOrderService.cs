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
    public class WorkOrderService : IWorkOrderService
    {
        private readonly IWorkOrderRepository _workOrderRepository;

        public WorkOrderService(IWorkOrderRepository workOrderRepository) => (_workOrderRepository) = (workOrderRepository);

        #region Создать новый заказ
        public Task<IBaseResponse<bool>> Create(WorkOrder entity)
        {

        }
        #endregion

        #region Удалить заказ из базы
        public Task<IBaseResponse<bool>> Delete(WorkOrder entity)
        {

        }
        #endregion

        #region Получить заказ из базы по номеру
        public Task<IBaseResponse<WorkOrder>> GetById(int id)
        {

        }
        #endregion

        #region Получить коллекцию всех заказов
        public async Task<IBaseResponse<IEnumerable<WorkOrder>>> GetAllWorkOrders()
        {
            var baseResponse = new BaseResponse<IEnumerable<WorkOrder>>();

            try
            {
                var workOrders = await _workOrderRepository.Select();
                if (workOrders.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;
                baseResponse.StatusCode = StatusCode.Ok;

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
        #endregion

        #region Получить коллекцию заказов из базы по отдельной категории
        public Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByActivityCategoryId(int activityCategoryId)
        {

        }
        #endregion

        #region Получить коллекцию заказов из базы по отдельному заказчику
        public Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByEmployerId(int employerId)
        {

        }
        #endregion

        #region Получить заказ из базы по названию
        public Task<IBaseResponse<WorkOrder>> GetByTitle(string title)
        {

        }
        #endregion

    }
}
