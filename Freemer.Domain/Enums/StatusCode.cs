﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.Domain.Enums
{
    public enum StatusCode
    {
        WorkOrderNotFound = 0,
        CategoryNotFound = 2,
        Ok = 200,
        InternalServerError = 500
    }
}
