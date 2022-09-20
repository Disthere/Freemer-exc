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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Order entity)
        {
            await _dbContext.Order.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
          
        public async Task<Order> GetById(int id)
        {
            return await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetByJobCategoryId(int jobCategoryId)
        {
            return await _dbContext.Order.Where(x => x.JobCategoryId == jobCategoryId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByEmployerId(int employerId)
        {
            return await _dbContext.Order.Where(x => x.EmployerId == employerId).ToListAsync();
        }

        public async Task<Order> GetByTitle(string title)
        {
            return await _dbContext.Order.FirstOrDefaultAsync(x => x.Title == title);
        }

        
        public async Task<List<Order>> Select()
        {
            return await _dbContext.Order.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByWorkerId(int workerId)
        {
            return await _dbContext.Order.Where(x => x.WorkerId == workerId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByLocationId(int locationId)
        {
            return await _dbContext.Order.Where(x => x.LocationId == locationId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByModerationStatus(int moderationStatus)
        {
            return await _dbContext.Order.Where(x => x.ModerationStatus == (OrderModerationStatus)moderationStatus).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByRelevance(int relevance)
        {
            return await _dbContext.Order.Where(x => x.Relevance == (OrderRelevance)relevance).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetBySomeProperty(string someProperty)
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

        public async Task<bool> Update(int id, Order updatedEntity)
        {
            try
            {
                var order = await GetById(id);

                {
                    order.Title = updatedEntity.Title;
                    order.Description = updatedEntity.Description;
                    order.CreationDate = updatedEntity.CreationDate;
                    order.EmployerId = updatedEntity.EmployerId;
                    order.JobCategoryId = updatedEntity.JobCategoryId;
                    order.LocationId = updatedEntity.LocationId;
                    order.OrderType = updatedEntity.OrderType;
                    order.TimeOver = updatedEntity.TimeOver;
                    order.StartPrice = updatedEntity.StartPrice;
                    order.FinalPrice = updatedEntity.FinalPrice;
                    order.WorkerId = updatedEntity.WorkerId;
                    order.OtherInfo = updatedEntity.OtherInfo;
                    order.ModerationStatus = updatedEntity.ModerationStatus;
                    order.Relevance = updatedEntity.Relevance;
                }

                _dbContext.Order.Update(order);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<bool> Delete(Order entity)
        {
            try
            {
                _dbContext.Order.Remove(entity);
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
