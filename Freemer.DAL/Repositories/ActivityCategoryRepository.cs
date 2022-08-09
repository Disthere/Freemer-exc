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

        public Task<bool> Create(ActivityCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ActivityCategory entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ActivityCategory> Get(int id)
        {
            return await _dbContext.ActivityCategory.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<ActivityCategory> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActivityCategory>> GetByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ActivityCategory>> Select()
        {
            throw new NotImplementedException();
        }
    }
}
