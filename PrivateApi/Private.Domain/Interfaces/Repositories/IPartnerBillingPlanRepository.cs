using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Repositories
{
    public interface IPartnerBillingPlanRepository : IRepository<PartnerBillingPlanEntity>
    {
        Task<List<PartnerBillingPlanEntity>> SelectPlanByDateOfTerm(Int64 idPartnerPerson, Int64 idBillingPlan, DateTime startOfTerm, DateTime endtOfTerm);
    }
}
