using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IWorkOrderService 
    {
        Task<IBaseResponse<bool>> Create(WorkOrder entity);


        Task<IBaseResponse<bool>> Delete(WorkOrder entity);


        Task<IBaseResponse<WorkOrder>> GetById(int id);


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByActivityCategoryId(int activityCategoryId);


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByEmployerId(int employerId);


        Task<IBaseResponse<WorkOrder>> GetByTitle(string title);
                               

        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetAllWorkOrders();
    }
}
