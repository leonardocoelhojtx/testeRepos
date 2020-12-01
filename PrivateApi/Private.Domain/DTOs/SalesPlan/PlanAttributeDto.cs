using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.SalesPlan
{
    public class PlanAttributeDto
    {
        public Int64 Id { get; set; }
        public Int64 IdBillingAttribute { get; set; }
        public Int64 IdBillingPlan { get; set; }
        public Int64 InclusionIdUser { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64 ChangeIdUser { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public double Quantity { get; set; }
    }
}
