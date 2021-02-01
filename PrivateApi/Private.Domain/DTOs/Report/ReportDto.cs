using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.Report
{
    public class ReportDto
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 CNPJ { get; set; }
        public string Phone { get; set; }
        public DateTime InclusionDateTime { get; set; }
        public Int64? QuantityFound { get; set; }
        public Int64? QuantityNotFound { get; set; }
        public decimal? PercentageFound { get; set; }
        public decimal? PercentageNotFound { get; set; }
        public decimal? InconsistentAmount { get; set; }
        public decimal? InconsistentAmountNCM { get; set; }
        public int MorePisCofins { get; set; }
        public decimal PercentageMorePisCofins { get; set; }
        public int LessPisCofins { get; set; }
        public decimal PercentageLessPisCofins { get; set; }
        public int DivergentNcm { get; set; }
        public decimal PercentageDivergentNcm { get; set; }
        public int DivergentIcms { get; set; }
        public decimal PercentageDivergentIcms { get; set; }
        public int DivergentPisCofins { get; set; }
        public decimal PercentageDivergentPisCofins { get; set; }
        public int DivergentIpi { get; set; }
        public decimal PercentageDivergentIpi { get; set; }
        public List<ItemReportDto> Products { get; set; }
    }
}
