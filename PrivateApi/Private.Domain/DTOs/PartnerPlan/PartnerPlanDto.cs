using Private.Domain.DTOs.SalesPlan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.PartnerPlan
{
    public class PartnerPlanDto
    {
        public Int64 Id { get; set; }
        public Int64 IdPartnerPerson { get; set; }
        public string ReasonName { get; set; }
        public string Fantasy { get; set; }
        public string ChargeResponsible { get; set; }
        public string AccessCode { get; set; }
        public DateTime StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public Int64 IdBillingPlan { get; set; }
        public string BillingPlanCode { get; set; }
        public string BillingPlanDescription { get; set; }
        public Int64? EffectiveDays { get; set; }        
        public Int64? GraceDays { get; set; }
        public string BillingCycle { get; set; }
        public double SaleValue { get; set; }
        public double? PartnerValue { get; set; }        
        public double? ResaleValue { get; set; }
        public string Visibility { get; set; }
        public string Situation { get; set; }
        public List<PartnerPlanAttributesDto> Attributes { get; set; }
    }

    public class PartnerPlanAttributesDto
    {
        public string Feature { get; set; }
        public double? Quantity { get; set; }
        public string Unlimited { get; set; }
        public Int64 IdPlanAttribute { get; set; }
    }
}
