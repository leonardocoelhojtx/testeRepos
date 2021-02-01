using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Private.Domain.DTOs.SalesPlan;

namespace Private.Data.Repository
{
    public class BillingPlanRepositoryReadOnly : BaseRepositoryReadOnly<BillingPlanEntity>, IBillingPlanRepositoryReadOnly
    {
        private readonly PrivateApiReadOnlyContext _context;
        public BillingPlanRepositoryReadOnly(PrivateApiReadOnlyContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<BillingPlanDto> SelectBillingPlans()
        {
            try
            {
                var query = (from a in _context.BillingPlans
                             where a.Situation == "A"
                            select new BillingPlanDto 
                            { 
                                Id = a.Id,
                                Code = a.Code,
                                Description = a.Description,
                                Situation = a.Situation,
                                StartOfTerm = a.StartOfTerm,
                                EndOfTerm = a.EndOfTerm,
                                Value = a.Value,
                                EffectiveDays = a.EffectiveDays,
                                GraceDays = a.GraceDays,
                                BillingCycle = a.BillingCycle,
                                InclusionDateTime = a.InclusionDateTime,
                                ChangeDateTime = a.ChangeDateTime,
                                Attributes = (from b in _context.PlanAttributes
                                              join c in _context.BillingAttributes on b.IdBillingAttribute equals c.Id
                                              where b.IdBillingPlan == a.Id
                                              select new AttributesPlanDto { 
                                                  Attribute = c.Attribute,
                                                  Value = c.Value, 
                                                  Quantity = b.Quantity }).ToList()                      
                            });

                return query;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
