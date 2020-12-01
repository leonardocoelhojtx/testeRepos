using Microsoft.EntityFrameworkCore;
using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Private.Data.Repository
{
    public class PartnerBillingPlanRepository : BaseRepository<PartnerBillingPlanEntity>, IPartnerBillingPlanRepository
    {
        private DbSet<PartnerBillingPlanEntity> _dataset;
        public PartnerBillingPlanRepository(PrivateApiContext context) : base(context)
        {
            _dataset = context.Set<PartnerBillingPlanEntity>();
        }

        public async Task<List<PartnerBillingPlanEntity>> SelectPlanByDateOfTerm(Int64 idPartnerPerson, Int64 idBillingPlan, DateTime startOfTerm, DateTime endtOfTerm)
        {
            try
            {
                return await _dataset.AsNoTracking().Where(x => x.IdPartnerPerson == idPartnerPerson && 
                                    x.IdBillingPlan == idBillingPlan &&
                                    x.StartOfTerm == startOfTerm && x.EndOfTerm == endtOfTerm 
                                    && x.Situation == "A").ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
