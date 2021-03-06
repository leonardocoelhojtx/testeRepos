﻿using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.Interfaces.Repositories
{
    public interface ICustomerRepositoryReadOnly : IRepositoryReadOnly<CustomerViewEntity>
    {
    }
}
