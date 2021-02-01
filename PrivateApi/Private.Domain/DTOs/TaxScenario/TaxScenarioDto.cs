using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.TaxScenario
{
    public class TaxScenarioDto
    {
        public Int64 Id { get; set; }
        public string Description { get; set; }
        public Int64 IdRegime { get; set; }
        public string RegimeDescription { get; set; }
        public Int64? IdOriginProfile { get; set; }
        public string OriginProfileDescription { get; set; }
        public Int64? IdDestinationProfile { get; set; }
        public string DestinationProfileDescription { get; set; }
        public string OriginUF { get; set; }
        public string DestinationUF { get; set; }
        public string CNAE { get; set; }
        public DateTime StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public Int64? IdOperationNature { get; set; }
        public string OperationNatureDescription { get; set; }
        public string Status { get; set; }
        public Int64 InclusionIdUser { get; set; }
        public string InclusionUserName { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64 ChangeIdUser { get; set; }
        public string ChangeUserName { get; set; }
        public DateTime ChangeDateTime { get; set; }
    }
}
