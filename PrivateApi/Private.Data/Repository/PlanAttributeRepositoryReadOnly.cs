using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Private.Data.Repository
{
    public class PlanAttributeRepositoryReadOnly : BaseRepositoryReadOnly<PlanAttributeEntity>, IPlanAttributeRepositoryReadOnly
    {
        private readonly PrivateApiReadOnlyContext _context;
        public PlanAttributeRepositoryReadOnly(PrivateApiReadOnlyContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PlanAttributeEntity> SelectPlanAttribute()
        {
            try
            {
                return _context.PlanAttributes;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
