using Freemer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.DAL.Interfaces
{
    public interface IActivityCategoryRepository : IBaseRepository<ActivityCategory>
    {
        Task<ActivityCategory> GetByName(string name);
        Task<IEnumerable<ActivityCategory>> GetByParentId(int parentId);
    }
}
