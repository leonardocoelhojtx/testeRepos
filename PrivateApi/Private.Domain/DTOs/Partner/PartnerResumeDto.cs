using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.Partner
{
    public class PartnerResumeDto
    {
        public Int64 Id { get; set; }
        public string ReasonName { get; set; }
        public string Fantasy { get; set; }
        public Int64 CpfCnpj { get; set; }
        public string Status { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public string Hash { get; set; }
    }
}
