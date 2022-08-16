using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Response;
using Freemer.Domain.ViewModels.WorkOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IWorkOrderService
    {
        Task<IBaseResponse<WorkOrderViewModel>> Create(WorkOrderViewModel workOrderViewModel);


        Task<IBaseResponse<WorkOrder>> GetById(int id);


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetAllWorkOrders();


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByActivityCategoryId(int activityCategoryId);


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByEmployerId(int employerId);


        Task<IBaseResponse<WorkOrder>> GetByTitle(string title);


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByWorkerId(int workerId);


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByLocationId(int locationId);


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByModerationStatus(int moderationStatus);


        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetByRelevance(int relevance);


        Task<IBaseResponse<bool>> Update(int id, WorkOrder updatedWorkOrder);


        Task<IBaseResponse<bool>> Delete(int id);
    }
}
