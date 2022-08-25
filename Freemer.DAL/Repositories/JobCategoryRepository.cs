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
    public class JobCategoryRepository : IJobCategoryRepository
    {
        
        private readonly ApplicationDbContext _dbContext;

        public JobCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> Create(JobCategory entity)
        {
            await _dbContext.JobCategory.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(JobCategory entity)
        {
            _dbContext.JobCategory.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<JobCategory> GetById(int id)
        {
            return await _dbContext.JobCategory.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<JobCategory> GetByName(string name)
        {
            return await _dbContext.JobCategory.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<JobCategory>> GetByParentId(int parentId)
        {
            return await _dbContext.JobCategory.Where(x => x.ParentId == parentId).ToListAsync();
        }

        public async Task<List<JobCategory>> Select()
        {
            return await _dbContext.JobCategory.ToListAsync();
        }

        public Task<bool> Update(int id, JobCategory updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
