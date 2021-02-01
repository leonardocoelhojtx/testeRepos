using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Private.Data.Repository
{
    public class BillingAttributeRepositoryReadOnly : BaseRepositoryReadOnly<BillingAttributeEntity>, IBillingAttributeRepositoryReadOnly
    {
        private readonly PrivateApiReadOnlyContext _context;
        public BillingAttributeRepositoryReadOnly(PrivateApiReadOnlyContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<BillingAttributeEntity> SelectBillingAttributes()
        {
            try
            {
                return _context.BillingAttributes;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
