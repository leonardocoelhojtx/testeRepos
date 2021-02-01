using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.SalesPlan
{
    public class BillingAttributeDto
    {
        public Int64 Id { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
        public Int64 InclusionIdUser { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64 ChangeIdUser { get; set; }
        public DateTime ChangeDateTime { get; set; }
    }
}
