using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.DAL.Repositories
{
    public class ActivityCategoryRepository : IActivityCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ActivityCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(ActivityCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ActivityCategory entity)
        {
            throw new NotImplementedException();
        }

        public ActivityCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        public ActivityCategory GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityCategory> GetByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ActivityCategory>> Select()
        {
            return _dbContext.ActivityCategory.ToListAsync();
        }
    }
}
