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
        WorkOrder GetByTitle(string title);
        IEnumerable<WorkOrder> GetByActivityCategoryId(int activityCategoryId);
        IEnumerable<WorkOrder> GetByEmployerId(int employerId);
    }
}
