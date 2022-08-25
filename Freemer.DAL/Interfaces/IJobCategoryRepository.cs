using Freemer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.DAL.Interfaces
{
    public interface IJobCategoryRepository : IBaseRepository<JobCategory>
    {
        Task<JobCategory> GetByName(string name);
        Task<IEnumerable<JobCategory>> GetByParentId(int parentId);
    }
}
