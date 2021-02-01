using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.Report
{
    public class ItemReportDto
    {
        public string ReportedCode { get; set; }
        public string InformedDescription { get; set; }
        public string Found { get; set; }
        public string InconsistentTaxation { get; set; }
        public string InconsistentNCM { get; set; }
        public decimal? NCM { get; set; }
        public decimal? IdealNCM { get; set; }
        public decimal? ICMS { get; set; }
        public decimal? IdealICMS { get; set; }
        public decimal? PIS { get; set; }
        public decimal? IdealPIS { get; set; }
        public decimal? COFINS { get; set; }
        public decimal? IdealCOFINS { get; set; }
        public decimal? IPI { get; set; }
        public decimal? IdealIPI { get; set; }
        public int NullableFields { get; set; }
    }
}
