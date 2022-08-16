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


        public async Task<bool> Create(ActivityCategory entity)
        {
            await _dbContext.ActivityCategory.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(ActivityCategory entity)
        {
            _dbContext.ActivityCategory.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ActivityCategory> GetById(int id)
        {
            return await _dbContext.ActivityCategory.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ActivityCategory> GetByName(string name)
        {
            return await _dbContext.ActivityCategory.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<ActivityCategory>> GetByParentId(int parentId)
        {
            return await _dbContext.ActivityCategory.Where(x => x.ParentId == parentId).ToListAsync();
        }

        public async Task<List<ActivityCategory>> Select()
        {
            return await _dbContext.ActivityCategory.ToListAsync();
        }
    }
}
