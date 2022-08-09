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
    }
}
