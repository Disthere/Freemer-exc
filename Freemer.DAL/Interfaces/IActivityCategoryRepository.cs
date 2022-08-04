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
        ActivityCategory GetByName(string name);
        IEnumerable<ActivityCategory> GetByParentId(int parentId);
    }
}
