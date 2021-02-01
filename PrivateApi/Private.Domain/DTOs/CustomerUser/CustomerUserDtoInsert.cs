using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.CustomerUser
{
    public class CustomerUserDtoInsert
    {
        public Int64 IdCustomer { get; set; }
        public Int64 IdUser { get; set; }
        public string Situation { get; set; }
        public Int64 InclusionIdUser { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64? ChangeIdUser { get; set; }
        public DateTime? ChangeDateTime { get; set; }
    }
}
