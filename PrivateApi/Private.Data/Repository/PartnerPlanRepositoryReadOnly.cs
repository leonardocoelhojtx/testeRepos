using Microsoft.EntityFrameworkCore;
using Private.Data.Context;
using Private.Domain.DTOs.PartnerPlan;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Private.Data.Repository
{
    public class PartnerPlanRepositoryReadOnly : BaseRepositoryReadOnly<PartnerPlanViewEntity>, IPartnerPlanRepositoryReadOnly
    {
        private readonly PrivateApiReadOnlyContext _context;

        public PartnerPlanRepositoryReadOnly(PrivateApiReadOnlyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PartnerPlanViewEntity>> GetPartnerPlan(long idPartner)
        {
            try
            {
                return await _context.PartnerPlans.AsNoTracking().Where(x => x.IdPartnerPerson == idPartner).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PartnerPlanViewEntity>> GetPartnerPlanById(Int64 idPartnerBillingPlan)
        {
            try
            {
                return await _context.PartnerPlans.AsNoTracking().Where(x => x.Id == idPartnerBillingPlan).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
