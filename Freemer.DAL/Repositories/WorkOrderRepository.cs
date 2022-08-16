using Freemer.DAL.Interfaces;
using Freemer.Domain.Entities;
using Freemer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
          
        public async Task<WorkOrder> GetById(int id)
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

        public async Task<IEnumerable<WorkOrder>> GetByWorkerId(int workerId)
        {
            return await _dbContext.WorkOrder.Where(x => x.WorkerId == workerId).ToListAsync();
        }

        public async Task<IEnumerable<WorkOrder>> GetByLocationId(int locationId)
        {
            return await _dbContext.WorkOrder.Where(x => x.LocationId == locationId).ToListAsync();
        }

        public async Task<IEnumerable<WorkOrder>> GetByModerationStatus(int moderationStatus)
        {
            return await _dbContext.WorkOrder.Where(x => x.ModerationStatus == (WorkOrderModerationStatus)moderationStatus).ToListAsync();
        }

        public async Task<IEnumerable<WorkOrder>> GetByRelevance(int relevance)
        {
            return await _dbContext.WorkOrder.Where(x => x.Relevance == (WorkOrderRelevance)relevance).ToListAsync();
        }

        public async Task<IEnumerable<WorkOrder>> GetBySomeProperty(string someProperty)
        {
            throw new NotImplementedException();
            //PropertyInfo[] myPropertyInfo;
            //Type myType = typeof(WorkOrder);
            //myPropertyInfo = myType.GetProperties();
            //List<string> workOrderProperty = new List<string>();
            //foreach (var item in myPropertyInfo)
            //{
            //   workOrderProperty.Add(item.ToString());
            //}
            //if (workOrderProperty.Contains(someProperty))
            //{

            //}
            //return await _dbContext.WorkOrder.Where(p =>
            //{
            //    PropertyInfo propertyInfo = typeof(WorkOrder).GetProperty(someProperty);

            //}).ToListAsync();
            ////Include(x=>x. Select(x => x.workOrderProperty[0]).ToListAsync();
            ////Where(x => x. == activityCategoryId).ToListAsync();
        }

        public async Task<bool> Update(int id, WorkOrder updatedEntity)
        {
            try
            {
                var workOrder = updatedEntity;
                workOrder.Id = id;
               _dbContext.WorkOrder.Update(workOrder);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<bool> Delete(WorkOrder entity)
        {
            try
            {
                _dbContext.WorkOrder.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
