using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.QueryLog
{
    public class QueryLogDto
    {
        public Int64 Id { get; set; }
        public Int64 Type { get; set; }
        public DateTime QueryDateTime { get; set; }
        public string Description { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64? IdCustomer { get; set; }
        public string CustomerReasonName { get; set; }
        public string CustomerFantasy { get; set; }
        public Int64? IdPartner { get; set; }
        public string PartnerReasonName { get; set; }
        public string PartnerFantasy { get; set; }
        public string URL { get; set; }
        public Int64? Pointer { get; set; }   
        public Int64? IdProduct { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNcm { get; set; }
        public string ProductGtin { get; set; }
        public Int64 InclusionIdUser { get; set; }
        public string InclusionUserName { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public Int64 ChangeIdUser { get; set; }
        public string ChangeUserName { get; set; }
    }
}
