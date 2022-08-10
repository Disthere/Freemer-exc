using Freemer.Domain.Entities;
using Freemer.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IWorkOrderService
    {
        Task<IBaseResponse<IEnumerable<WorkOrder>>> GetAllWorkOrders();
    }
}
