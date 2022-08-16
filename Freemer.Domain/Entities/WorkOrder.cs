using Freemer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.Domain.Entities
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int EmployerId { get; set; }
        public int ActivityCategoryId { get; set; }
        public int LocationId { get; set; }
        public string OrderType { get; set; }
        public TimeSpan TimeOver { get; set; }
        public decimal StartPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public int WorkerId { get; set; }
        public string OtherInfo { get; set; }

        [DefaultValue(WorkOrderModerationStatus.NotModerated)] //(отдельная таблица с причинами отказа в публикации)
        public WorkOrderModerationStatus ModerationStatus { get; set; }

        [DefaultValue(WorkOrderRelevance.NotPublished)]
        public WorkOrderRelevance Relevance { get; set; }

    }
}

