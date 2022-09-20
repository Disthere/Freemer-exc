using Freemer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; } // Использовать тип Guid
        public string Title { get; set; }
        public string Description { get; set; }
        public int JobCategoryId { get; set; }
        public string OrderType { get; set; } // Отдельная таблица с типами заказов
        public string OtherInfo { get; set; }


        // Вынести в отдельную таблицу с заказчиками
        public int EmployerId { get; set; }

        // Вынести в отдельную таблицу с временными метками заказа
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public TimeSpan TimeOver { get; set; }


        // Вынести в отдельную таблицу
        public int LocationId { get; set; }


        // Вынести в отдельную таблицу с ценовыми характеристиками заказа
        public decimal StartPrice { get; set; }
        public decimal FinalPrice { get; set; }


        // Вынести в отдельную таблицу с исполнителями
        public int WorkerId { get; set; }


        //(отдельная таблица с причинами отказа в публикации, датой модерации и отправки результата модерации заказчику)
        [DefaultValue(OrderModerationStatus.NotModerated)]
        public OrderModerationStatus ModerationStatus { get; set; }


        //(отдельная таблица с датами публикации, снятия с публикации)
        [DefaultValue(OrderRelevance.NotPublished)]
        public OrderRelevance Relevance { get; set; }

    }
}

