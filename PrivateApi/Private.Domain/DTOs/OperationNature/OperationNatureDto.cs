using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.OperationNature
{
    public class OperationNatureDto
    {
        public Int64 Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64 InclusionIdUser { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public Int64 ChangeIdUser { get; set; }
    }
}
