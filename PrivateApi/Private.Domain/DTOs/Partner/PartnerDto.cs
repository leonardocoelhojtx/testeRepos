using Private.Domain.DTOs.PersonAddress;
using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.Partner
{
    public class PartnerDto
    {
        public Int64 Id { get; set; }
        public Int64 IdPerson { get; set; }
        public string ReasonName { get; set; }
        public string Fantasy { get; set; }
        public Int64 CpfCnpj { get; set; }
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternativePhone { get; set; }
        public string Status { get; set; }
        public Int64 InclusionIdUser { get; set; }
        public string InclusionUserName { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64 ChangeIdUser { get; set; }
        public string ChangeUserName { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public string ContactName { get; set; }
        public string ChargeResponsible { get; set; }
        public List<PersonAddressDto> Address { get; set; }
    }
}