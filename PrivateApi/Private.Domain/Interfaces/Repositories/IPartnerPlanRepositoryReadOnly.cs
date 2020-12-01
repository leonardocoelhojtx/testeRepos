using Private.Domain.DTOs.PartnerPlan;
using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Repositories
{
    public interface IPartnerPlanRepositoryReadOnly : IRepositoryReadOnly<PartnerPlanViewEntity>
    {
        Task<IEnumerable<PartnerPlanViewEntity>> GetPartnerPlan(Int64 idPartner);
        Task<IEnumerable<PartnerPlanViewEntity>> GetPartnerPlanById(Int64 idPartnerBillingPlan);
    }
}
