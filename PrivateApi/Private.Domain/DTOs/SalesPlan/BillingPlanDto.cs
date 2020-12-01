using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.SalesPlan
{
    public class BillingPlanDto
    {
        public Int64 Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Situation { get; set; }
        public DateTime StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public double Value { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public Int64? EffectiveDays { get; set; }
        public Int64? GraceDays { get; set; }
        public string BillingCycle { get; set; }
        public List<AttributesPlanDto> Attributes { get; set; }
    }

    public class AttributesPlanDto 
    {
        public string Attribute { get; set; }
        public string Value { get; set; }
        public double Quantity { get; set; }
    }
}
