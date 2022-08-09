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
        public bool Create(WorkOrder entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(WorkOrder entity)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkOrder> Get(int id)
        {
            return await _dbContext.WorkOrder.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<WorkOrder> GetByActivityCategoryId(int activityCategoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrder> GetByEmployerId(int employerId)
        {
            throw new NotImplementedException();
        }

        public WorkOrder GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        // Async - для безостановочной работы сайта при обращении к базе данных
        public async Task<List<WorkOrder>> Select()
        {
            return await _dbContext.WorkOrder.ToListAsync();
        }
    }
}
