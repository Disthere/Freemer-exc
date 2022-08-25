using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Response;
using Freemer.Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<OrderViewModel>> Create(OrderViewModel orderViewModel);


        Task<IBaseResponse<Order>> GetById(int id);


        Task<IBaseResponse<IEnumerable<Order>>> GetAllOrders();


        Task<IBaseResponse<IEnumerable<Order>>> GetByJobCategoryId(int jobCategoryId);


        Task<IBaseResponse<IEnumerable<Order>>> GetByEmployerId(int employerId);


        Task<IBaseResponse<Order>> GetByTitle(string title);


        Task<IBaseResponse<IEnumerable<Order>>> GetByWorkerId(int workerId);


        Task<IBaseResponse<IEnumerable<Order>>> GetByLocationId(int locationId);


        Task<IBaseResponse<IEnumerable<Order>>> GetByModerationStatus(int moderationStatus);


        Task<IBaseResponse<IEnumerable<Order>>> GetByRelevance(int relevance);


        Task<IBaseResponse<bool>> Update(int id, Order updatedOrder);


        Task<IBaseResponse<bool>> Delete(int id);
    }
}
