﻿using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Private.Domain.Interfaces.Repositories
{
    public interface IPlanAttributeRepositoryReadOnly : IRepositoryReadOnly<PlanAttributeEntity>
    {
        IQueryable<PlanAttributeEntity> SelectPlanAttribute();
    }
}
