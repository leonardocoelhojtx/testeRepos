using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.Customer
{
    public class CustomerUserDto
    {
        public Int64 Id { get; set; }
        public Int64 IdUser { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Situation { get; set; }
        public DateTime InclusionDateTime { get; set; }
    }
}
