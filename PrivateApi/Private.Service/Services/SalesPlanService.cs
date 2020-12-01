using AutoMapper;
using Private.Domain.DTOs.SalesPlan;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Private.Domain.Models;
using Private.Domain.Entities;

namespace Private.Service.Services
{
    public class SalesPlanService : ISalesPlanService
    {
        private readonly IBillingAttributeRepositoryReadOnly _salesPlanRepoReadOnly;
        private readonly IBillingAttributeRepository _salesPlanRepo;
        private readonly IBillingPlanRepositoryReadOnly _billingPlanRepoReadOnly;
        private readonly IBillingPlanRepository _billingPlanRepo;
        private readonly IPlanAttributeRepositoryReadOnly _planAttributeRepoReadOnly;
        private readonly IPlanAttributeRepository _planAttributeRepo;
        private readonly IMapper _mapper;

        public SalesPlanService(
            IBillingAttributeRepositoryReadOnly salesPlanRepoReadOnly,
            IBillingAttributeRepository salesPlanRepo,
            IBillingPlanRepositoryReadOnly billingPlanRepoReadOnly,
            IBillingPlanRepository billingPlanRepo,
            IPlanAttributeRepositoryReadOnly planAttributeRepoReadOnly,
            IPlanAttributeRepository planAttributeRepo,
            IMapper mapper  
        )
        {
            _salesPlanRepoReadOnly = salesPlanRepoReadOnly;
            _salesPlanRepo = salesPlanRepo;
            _billingPlanRepoReadOnly = billingPlanRepoReadOnly;
            _billingPlanRepo = billingPlanRepo;
            _planAttributeRepoReadOnly = planAttributeRepoReadOnly;
            _planAttributeRepo = planAttributeRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillingAttributeDto>> GetAllBillingAttributeByFilters(string attribute, string value)
        {
            var query = _salesPlanRepoReadOnly.SelectBillingAttributes();

            if (!String.IsNullOrEmpty(attribute))
                query = query.Where(x => x.Attribute.ToLower().Contains(attribute.ToLower()));

            if (!String.IsNullOrEmpty(value))
                query = query.Where(x => x.Value.ToLower().Contains(value.ToLower()));

            var listSalesPlans = await query.ToListAsync();

            return _mapper.Map<List<BillingAttributeDto>>(listSalesPlans);
        }

        public async Task<BillingAttributeDto> GetBillingAttributeByAttribute(string attribute)
        {
            var salesPlanEntity = await _salesPlanRepoReadOnly.SelectBillingAttributes().Where(x => x.Attribute.ToLower() == attribute.ToLower()).FirstOrDefaultAsync();

            return _mapper.Map<BillingAttributeDto>(salesPlanEntity);
        }

        public async Task<BillingAttributeDto> GetBillingAttributeById(Int64 id)
        {
            var salesPlanEntity = await _salesPlanRepoReadOnly.SelectBillingAttributes().Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<BillingAttributeDto>(salesPlanEntity);
        }

        public async Task<BillingAttributeDto> PostBillingAttribute(BillingAttributeDtoInsert salesPlan, Int64 idUser)
        {
            var querySalesPlanEntity = _salesPlanRepoReadOnly.SelectBillingAttributes().Where(x => x.Attribute.ToLower() == salesPlan.Attribute.ToLower()).FirstOrDefault();

            if (querySalesPlanEntity != null)
                return null;

            var salesPlanModel = _mapper.Map<BillingAttributeModel>(salesPlan);
            salesPlanModel.Attribute = salesPlan.Attribute.ToLower();
            salesPlanModel.Status = String.IsNullOrEmpty(salesPlan.Status) ? "A" : salesPlan.Status;
            salesPlanModel.InclusionIdUser = idUser;
            salesPlanModel.ChangeIdUser = idUser;

            var salesPlanEntity = _mapper.Map<BillingAttributeEntity>(salesPlanModel);
            var result = await _salesPlanRepo.InsertAsync(salesPlanEntity);

            return _mapper.Map<BillingAttributeDto>(result);
        }

        public async Task<BillingAttributeDto> PutBillingAttribute(Int64 id, BillingAttributeDtoUpdate salesPlan, Int64 idUser)
        {
            var salesPlanEntity = await _salesPlanRepoReadOnly.SelectAsync(id);

            if (salesPlanEntity == null)
                return null;

            salesPlanEntity.Attribute = !String.IsNullOrEmpty(salesPlan.Attribute) ? salesPlan.Attribute.ToLower() : salesPlanEntity.Attribute;
            salesPlanEntity.Value = !String.IsNullOrEmpty(salesPlan.Value) ? salesPlan.Value : salesPlanEntity.Value;
            salesPlanEntity.Status = !String.IsNullOrEmpty(salesPlan.Status) ? salesPlan.Status : salesPlanEntity.Status;
            salesPlanEntity.ChangeIdUser = idUser;
            salesPlanEntity.ChangeDateTime = DateTime.Now;

            var result = await _salesPlanRepo.UpdateAsync(salesPlanEntity);

            return _mapper.Map<BillingAttributeDto>(result);
        }

        public async Task<BillingAttributeDto> DeleteBillingAttribute(Int64 id, Int64 idUser)
        {
            var salesPlanEntity = await _salesPlanRepoReadOnly.SelectAsync(id);

            if (salesPlanEntity == null)
                return null;

            salesPlanEntity.Status = "I";
            salesPlanEntity.ChangeIdUser = idUser;
            salesPlanEntity.ChangeDateTime = DateTime.Now;

            var result = await _salesPlanRepo.UpdateAsync(salesPlanEntity);

            return _mapper.Map<BillingAttributeDto>(result);
        }

        public async Task<IEnumerable<BillingPlanDto>> GetAllBillingPlansByFilters(string code, string description, string startOfTerm, string endOfTerm, string billingCycle)
        {
            var query = _billingPlanRepoReadOnly.SelectBillingPlans();

            if (!String.IsNullOrEmpty(code))
                query = query.Where(x => x.Code.ToUpper().Contains(code.ToUpper()));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(x => x.Description.ToUpper().Contains(description.ToUpper()));

            if (!String.IsNullOrEmpty(startOfTerm))
            {
                var startOfTermDateTime = Convert.ToDateTime(startOfTerm);
                query = query.Where(x => x.StartOfTerm >= startOfTermDateTime);
            }

            if (!String.IsNullOrEmpty(endOfTerm))
            {
                var endOfTermDateTime = Convert.ToDateTime(endOfTerm);
                query = query.Where(x => x.EndOfTerm <= endOfTermDateTime);
            }

            if (!String.IsNullOrEmpty(billingCycle))
                query = query.Where(x => x.BillingCycle.ToUpper().Contains(billingCycle.ToUpper()));

            var listBillingPlans = await query.OrderBy(x => x.Code).ThenBy(x => x.Description).ThenBy(x => x.EndOfTerm).ToListAsync();

            return listBillingPlans;
        }

        public async Task<BillingPlanDto> PostBillingPlan(BillingPlanDtoInsert billingPlan, Int64 idUser)
        {
            var exists = await _billingPlanRepoReadOnly.SelectBillingPlans()
                            .Where(x => x.Code.ToUpper() == billingPlan.Code.ToUpper()).FirstOrDefaultAsync();

            if (exists != null)
                return null;

            var billingPlanModel = _mapper.Map<BillingPlanModel>(billingPlan);
            billingPlanModel.Code = billingPlan.Code.ToUpper();
            billingPlanModel.Description = billingPlan.Description.ToUpper();
            billingPlanModel.Situation = String.IsNullOrEmpty(billingPlan.Situation) ? "A" : billingPlan.Situation.ToUpper();
            billingPlanModel.BillingCycle = billingPlan.BillingCycle.ToUpper();
            billingPlanModel.InclusionIdUser = idUser;
            billingPlanModel.ChangeIdUser = idUser;

            var billingPlanEntity = _mapper.Map<BillingPlanEntity>(billingPlanModel);
            var result = await _billingPlanRepo.InsertAsync(billingPlanEntity);

            foreach (var attribute in billingPlan.Attributes)
            {
                var planAttributeModel = _mapper.Map<PlanAttributeModel>(attribute);
                planAttributeModel.IdBillingPlan = result.Id;
                planAttributeModel.InclusionIdUser = idUser;
                planAttributeModel.ChangeIdUser = idUser;

                var planAttributeEntity = _mapper.Map<PlanAttributeEntity>(planAttributeModel);
                var resultAttributes = await _planAttributeRepo.InsertAsync(planAttributeEntity);
            }

            return await _billingPlanRepoReadOnly.SelectBillingPlans()
                            .Where(x => x.Code.ToUpper() == billingPlan.Code.ToUpper()).FirstOrDefaultAsync();
        }

        public async Task<BillingPlanDto> PutBillingPlan(Int64 id, BillingPlanDtoUpdate billingPlan, Int64 idUser)
        {
            var billingPlanEntity = await _billingPlanRepoReadOnly.SelectAsync(id);

            if (billingPlanEntity == null)
                return null;

            billingPlanEntity.Description = !String.IsNullOrEmpty(billingPlan.Description) ? billingPlan.Description : billingPlanEntity.Description;
            billingPlanEntity.Situation = !String.IsNullOrEmpty(billingPlan.Situation) ? billingPlan.Situation : billingPlanEntity.Situation;
            billingPlanEntity.StartOfTerm = billingPlan.StartOfTerm != null ? (DateTime)billingPlan.StartOfTerm : billingPlanEntity.StartOfTerm;
            billingPlanEntity.EndOfTerm = billingPlan.EndOfTerm;
            billingPlanEntity.Value = billingPlan.Value != null ? (double)billingPlan.Value : billingPlanEntity.Value;
            billingPlanEntity.EffectiveDays = billingPlan.EffectiveDays != null ? billingPlan.EffectiveDays : billingPlanEntity.EffectiveDays;
            billingPlanEntity.GraceDays = billingPlan.GraceDays != null ? billingPlan.GraceDays : billingPlanEntity.GraceDays;
            billingPlanEntity.BillingCycle = !String.IsNullOrEmpty(billingPlan.BillingCycle) ? billingPlan.BillingCycle : billingPlanEntity.BillingCycle;
            billingPlanEntity.ChangeIdUser = idUser;
            billingPlanEntity.ChangeDateTime = DateTime.Now;

            var result = await _billingPlanRepo.UpdateAsync(billingPlanEntity);

            return _mapper.Map<BillingPlanDto>(result);
        }

        public async Task<PlanAttributeDto> PostPlanAttribute(Int64 idBillingPlan, PlanAttributeDtoInsert planAttribute, Int64 idUser)
        {
            var billingPlanEntity = await _billingPlanRepoReadOnly.SelectAsync(idBillingPlan);

            if (billingPlanEntity == null)
                return null;

            var planAttributeModel = _mapper.Map<PlanAttributeModel>(planAttribute);
            planAttributeModel.IdBillingPlan = idBillingPlan;
            planAttributeModel.InclusionIdUser = idUser;
            planAttributeModel.ChangeIdUser = idUser;

            var planAttributeEntity = _mapper.Map<PlanAttributeEntity>(planAttributeModel);
            var result = await _planAttributeRepo.InsertAsync(planAttributeEntity);

            return _mapper.Map<PlanAttributeDto>(result);
        }

        public async Task<PlanAttributeDto> PutPlanAttribute(Int64 idBillingPlan, Int64 idBillingAttribute, PlanAttributeDtoUpdate planAttribute, Int64 idUser)
        {
            var planAttributeEntity = await _planAttributeRepoReadOnly.SelectPlanAttribute().Where(x => x.IdBillingAttribute == idBillingAttribute && x.IdBillingPlan == idBillingPlan).FirstOrDefaultAsync();

            if (planAttributeEntity == null)
                return null;

            planAttributeEntity.Quantity = planAttribute.Quantity;
            planAttributeEntity.ChangeIdUser = idUser;
            planAttributeEntity.ChangeDateTime = DateTime.Now;

            var result = await _planAttributeRepo.UpdateAsync(planAttributeEntity);

            return _mapper.Map<PlanAttributeDto>(result);
        }

        public async Task<BillingPlanDto> DeleteBillingPlan(long id, long idUser)
        {
            var billingPlanEntity = await _billingPlanRepoReadOnly.SelectAsync(id);

            if (billingPlanEntity == null)
                return null;

            billingPlanEntity.Situation = "I";
            billingPlanEntity.ChangeIdUser = idUser;
            billingPlanEntity.ChangeDateTime = DateTime.Now;

            var result = await _billingPlanRepo.UpdateAsync(billingPlanEntity);

            return _mapper.Map<BillingPlanDto>(result);
        }
    }
}