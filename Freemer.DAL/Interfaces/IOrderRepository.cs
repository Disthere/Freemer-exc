using Freemer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.DAL.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetByTitle(string title);
        Task<IEnumerable<Order>> GetByJobCategoryId(int jobCategoryId);
        Task<IEnumerable<Order>> GetByEmployerId(int employerId);
        Task<IEnumerable<Order>> GetByWorkerId(int workerId);
        Task<IEnumerable<Order>> GetByLocationId(int locationId);
        Task<IEnumerable<Order>> GetByModerationStatus(int moderationStatus);
        Task<IEnumerable<Order>> GetByRelevance(int relevance);
        Task<IEnumerable<Order>> GetBySomeProperty(string someProperty);


    }
}
