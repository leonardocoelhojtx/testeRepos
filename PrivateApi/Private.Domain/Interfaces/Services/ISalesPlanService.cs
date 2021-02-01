using Private.Domain.DTOs.SalesPlan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface ISalesPlanService
    {
        Task<IEnumerable<BillingAttributeDto>> GetAllBillingAttributeByFilters(string attribute, string value);
        Task<BillingAttributeDto> GetBillingAttributeByAttribute(string attribute);
        Task<BillingAttributeDto> GetBillingAttributeById(Int64 id);
        Task<BillingAttributeDto> PostBillingAttribute(BillingAttributeDtoInsert salesPlan, Int64 idUser);
        Task<BillingAttributeDto> PutBillingAttribute(Int64 id, BillingAttributeDtoUpdate salesPlan, Int64 idUser);
        Task<BillingAttributeDto> DeleteBillingAttribute(Int64 id, Int64 idUser);
        Task<IEnumerable<BillingPlanDto>> GetAllBillingPlansByFilters(string code, string description, string startOfTerm, string endOfTerm, string billingCycle);
        Task<BillingPlanDto> PostBillingPlan(BillingPlanDtoInsert billingPlan, Int64 idUser);
        Task<BillingPlanDto> PutBillingPlan(Int64 id, BillingPlanDtoUpdate billingPlan, Int64 idUser);
        Task<BillingPlanDto> DeleteBillingPlan(Int64 id, Int64 idUser);
        Task<PlanAttributeDto> PostPlanAttribute(Int64 idBillingPlan, PlanAttributeDtoInsert planAttribute, Int64 idUser);
        Task<PlanAttributeDto> PutPlanAttribute(Int64 idBillingPlan, Int64 idBillingAttribute, PlanAttributeDtoUpdate planAttribute, Int64 idUser);
    }
}
