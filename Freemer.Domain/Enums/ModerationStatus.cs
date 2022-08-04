using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.Domain.Enums
{
    public enum ModerationStatus
    {
        [Display(Name = "Не проверено")]
        NotModerated = 0,

        [Display(Name = "На проверке у модератора")]
        OnModeration = 1,

        [Display(Name = "Проверено и отклонено")]
        ModeratedAndRejected = 2,

        [Display(Name = "Проверено и одобрено")]
        ModeratedAndApproved = 3
    }
}
