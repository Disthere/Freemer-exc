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
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WorkOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(WorkOrder entity)
        {
            await _dbContext.WorkOrder.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(WorkOrder entity)
        {
            _dbContext.WorkOrder.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<WorkOrder> Get(int id)
        {
            return await _dbContext.WorkOrder.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<WorkOrder>> GetByActivityCategoryId(int activityCategoryId)
        {
            return await _dbContext.WorkOrder.Where(x => x.ActivityCategoryId == activityCategoryId).ToListAsync();
        }

        public async Task<IEnumerable<WorkOrder>> GetByEmployerId(int employerId)
        {
            return await _dbContext.WorkOrder.Where(x => x.EmployerId == employerId).ToListAsync();
        }

        public async Task<WorkOrder> GetByTitle(string title)
        {
            return await _dbContext.WorkOrder.FirstOrDefaultAsync(x => x.Title == title);
        }

        // Async - для безостановочной работы сайта при обращении к базе данных
        public async Task<List<WorkOrder>> Select()
        {
            return await _dbContext.WorkOrder.ToListAsync();
        }
    }
}
