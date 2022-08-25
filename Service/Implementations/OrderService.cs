using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
using Freemer.Domain.Response;
using Freemer.Domain.ViewModels.Order;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) => (_orderRepository) = (orderRepository);

        #region Создать новый заказ
        public async Task<IBaseResponse<OrderViewModel>> Create(OrderViewModel orderViewModel)
        {
            var baseResponse = new BaseResponse<OrderViewModel>();

            try
            {
                Order order = new()
                {
                    Title = orderViewModel.Title,
                    Description = orderViewModel.Description,
                    CreationDate = orderViewModel.CreationDate,
                    EmployerId = orderViewModel.EmployerId,
                    JobCategoryId = orderViewModel.JobCategoryId,
                    LocationId = orderViewModel.LocationId,
                    OrderType = orderViewModel.OrderType,
                    TimeOver = orderViewModel.TimeOver,
                    StartPrice = orderViewModel.StartPrice,
                    FinalPrice = orderViewModel.FinalPrice,
                    WorkerId = orderViewModel.WorkerId,
                    OtherInfo = orderViewModel.OtherInfo,
                    ModerationStatus = (OrderModerationStatus)Convert.ToInt32(orderViewModel.ModerationStatus),
                    Relevance = (OrderRelevance)Convert.ToInt32(orderViewModel.Relevance)
                };

                await _orderRepository.Create(order);

            }
            catch (Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
            return baseResponse;
        }
        #endregion


        #region Получить заказ из базы по номеру
        public async Task<IBaseResponse<Order>> GetById(int id)
        {
            var baseResponse = new BaseResponse<Order>();

            try
            {
                var order = await _orderRepository.GetById(id);

                if (order == null)
                {
                    baseResponse.Description = "Order not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = order;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = $"[GetById] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }
        #endregion

        #region Получить коллекцию всех заказов
        public async Task<IBaseResponse<IEnumerable<Order>>> GetAllOrders()
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.Select();
                if (orders.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = orders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetAllOrders] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion


        #region Получить коллекцию заказов из базы по отдельной категории
        public async Task<IBaseResponse<IEnumerable<Order>>> GetByJobCategoryId(int jobCategoryId)
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.GetByJobCategoryId(jobCategoryId);

                if (orders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = orders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetByJobCategoryId] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по отдельному заказчику
        public async Task<IBaseResponse<IEnumerable<Order>>> GetByEmployerId(int employerId)
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.GetByEmployerId(employerId);

                if (orders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = orders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetByEmployerId] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить заказ из базы по названию
        public async Task<IBaseResponse<Order>> GetByTitle(string title)
        {
            var baseResponse = new BaseResponse<Order>();

            try
            {
                var order = await _orderRepository.GetByTitle(title);

                if (order == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = order;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = $"[GetByTitle] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по отдельному исполнителю
        public async Task<IBaseResponse<IEnumerable<Order>>> GetByWorkerId(int workerId)
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.GetByWorkerId(workerId);

                if (orders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = orders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetByWorkerId] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по локации
        public async Task<IBaseResponse<IEnumerable<Order>>> GetByLocationId(int locationId)
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.GetByLocationId(locationId);

                if (orders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = orders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetByLocationId] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по статусу проверки модератором
        public async Task<IBaseResponse<IEnumerable<Order>>> GetByModerationStatus(int moderationStatus)
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.GetByModerationStatus(moderationStatus);

                if (orders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = orders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetByModerationStatus] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Получить коллекцию заказов из базы по статусу публикации и выполнения
        public async Task<IBaseResponse<IEnumerable<Order>>> GetByRelevance(int relevance)
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.GetByRelevance(relevance);

                if (orders == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = orders;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetByRelevance] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Обновить заказ в базе данных
        public async Task<IBaseResponse<bool>> Update(int id, Order updatedOrder)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };

            try
            {
                var order = await _orderRepository.GetById(id);

                if (order == null)
                {
                    baseResponse.Description = "Order not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _orderRepository.Update(id, updatedOrder);

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
                var order = await _orderRepository.GetById(id);

                if (order == null)
                {
                    baseResponse.Description = "Order not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.OrderNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _orderRepository.Delete(order);

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
