using Freemer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.DAL.Interfaces
{
    public interface IWorkOrderRepository : IBaseRepository<WorkOrder>
    {
        Task<WorkOrder> GetByTitle(string title);
        Task<IEnumerable<WorkOrder>> GetByActivityCategoryId(int activityCategoryId);
        Task<IEnumerable<WorkOrder>> GetByEmployerId(int employerId);
        Task<IEnumerable<WorkOrder>> GetByWorkerId(int workerId);
        Task<IEnumerable<WorkOrder>> GetByLocationId(int locationId);
        Task<IEnumerable<WorkOrder>> GetByModerationStatus(int moderationStatus);
        Task<IEnumerable<WorkOrder>> GetByRelevance(int relevance);
        Task<IEnumerable<WorkOrder>> GetBySomeProperty(string someProperty);


    }
}
