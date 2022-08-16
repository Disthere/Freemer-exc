using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
using Freemer.Domain.Response;
using Freemer.Domain.ViewModels.WorkOrder;
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
        public async Task<IBaseResponse<WorkOrderViewModel>> Create(WorkOrderViewModel workOrderViewModel)
        {
            var baseResponse = new BaseResponse<WorkOrderViewModel>();

            try
            {
                WorkOrder workOrder = new()
                {
                    Title = workOrderViewModel.Title,
                    Description = workOrderViewModel.Description,
                    CreationDate = workOrderViewModel.CreationDate,
                    EmployerId = workOrderViewModel.EmployerId,
                    ActivityCategoryId = workOrderViewModel.ActivityCategoryId,
                    LocationId = workOrderViewModel.LocationId,
                    OrderType = workOrderViewModel.OrderType,
                    TimeOver = workOrderViewModel.TimeOver,
                    StartPrice = workOrderViewModel.StartPrice,
                    FinalPrice = workOrderViewModel.FinalPrice,
                    WorkerId = workOrderViewModel.WorkerId,
                    OtherInfo = workOrderViewModel.OtherInfo,
                    ModerationStatus = (WorkOrderModerationStatus)Convert.ToInt32(workOrderViewModel.ModerationStatus),
                    Relevance = (WorkOrderRelevance)Convert.ToInt32(workOrderViewModel.Relevance)
                };

                await _workOrderRepository.Create(workOrder);

            }
            catch (Exception ex)
            {
                return new BaseResponse<WorkOrderViewModel>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
            return baseResponse;
        }
        #endregion


        #region Получить заказ из базы по номеру
        public async Task<IBaseResponse<WorkOrder>> GetById(int id)
        {
            var baseResponse = new BaseResponse<WorkOrder>();

            try
            {
                var workOrder = await _workOrderRepository.GetById(id);

                if (workOrder == null)
                {
                    baseResponse.Description = "WorkOrder not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrder;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<WorkOrder>()
                {
                    Description = $"[GetById] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
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
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WorkOrder>>()
                {
                    Description = $"[GetAllWorkOrders] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion


        #region Получить коллекцию заказов из базы по отдельной категории
        public async Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByActivityCategoryId(int activityCategoryId)
        {
            var baseResponse = new BaseResponse<IEnumerable<WorkOrder>>();

            try
            {
                var workOrders = await _workOrderRepository.GetByActivityCategoryId(activityCategoryId);

                if (workOrders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WorkOrder>>()
                {
                    Description = $"[GetByActivityCategoryId] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по отдельному заказчику
        public async Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByEmployerId(int employerId)
        {
            var baseResponse = new BaseResponse<IEnumerable<WorkOrder>>();

            try
            {
                var workOrders = await _workOrderRepository.GetByEmployerId(employerId);

                if (workOrders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WorkOrder>>()
                {
                    Description = $"[GetByEmployerId] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить заказ из базы по названию
        public async Task<IBaseResponse<WorkOrder>> GetByTitle(string title)
        {
            var baseResponse = new BaseResponse<WorkOrder>();

            try
            {
                var workOrder = await _workOrderRepository.GetByTitle(title);

                if (workOrder == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrder;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<WorkOrder>()
                {
                    Description = $"[GetByTitle] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по отдельному исполнителю
        public async Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByWorkerId(int workerId)
        {
            var baseResponse = new BaseResponse<IEnumerable<WorkOrder>>();

            try
            {
                var workOrders = await _workOrderRepository.GetByWorkerId(workerId);

                if (workOrders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WorkOrder>>()
                {
                    Description = $"[GetByWorkerId] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по локации
        public async Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByLocationId(int locationId)
        {
            var baseResponse = new BaseResponse<IEnumerable<WorkOrder>>();

            try
            {
                var workOrders = await _workOrderRepository.GetByLocationId(locationId);

                if (workOrders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WorkOrder>>()
                {
                    Description = $"[GetByLocationId] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по статусу проверки модератором
        public async Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByModerationStatus(int moderationStatus)
        {
            var baseResponse = new BaseResponse<IEnumerable<WorkOrder>>();

            try
            {
                var workOrders = await _workOrderRepository.GetByModerationStatus(moderationStatus);

                if (workOrders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WorkOrder>>()
                {
                    Description = $"[GetByModerationStatus] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по статусу публикации и выполнения
        public async Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByRelevance(int relevance)
        {
            var baseResponse = new BaseResponse<IEnumerable<WorkOrder>>();

            try
            {
                var workOrders = await _workOrderRepository.GetByRelevance(relevance);

                if (workOrders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = workOrders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<WorkOrder>>()
                {
                    Description = $"[GetByRelevance] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Обновить заказ в базе данных
        public async Task<IBaseResponse<bool>> Update(int id, WorkOrder updatedWorkOrder)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };

            try
            {
                var workOrder = await _workOrderRepository.GetById(id);

                if (workOrder == null)
                {
                    baseResponse.Description = "WorkOrder not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _workOrderRepository.Update(id, updatedWorkOrder);

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Update] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }
        #endregion

        #region Удалить заказ из базы
        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };

            try
            {
                var workOrder = await _workOrderRepository.GetById(id);

                if (workOrder == null)
                {
                    baseResponse.Description = "WorkOrder not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.WorkOrderNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _workOrderRepository.Delete(workOrder);

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }
        #endregion
    }
}
