using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("laudoitem")]
    public class ItemReportEntity : BaseEntity
    {
        [Required]
        [Column("idlaudoitem")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idlaudo")]
        public Int64 IdReport { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("codinformado")]
        public string ReportedCode { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("descricaoinformada")]
        public string InformedDescription { get; set; }

        [MaxLength(1)]
        [Column("encontrado")]
        public string Found { get; set; }

        [MaxLength(1)]
        [Column("inconsistentetrib")]
        public string InconsistentTaxation { get; set; }

        [MaxLength(1)]
        [Column("inconsistentencm")]
        public string InconsistentNCM { get; set; }

        [MaxLength(8)]
        [Column("ncm")]
        public string NCM { get; set; }

        [MaxLength(8)]
        [Column("ncmideal")]
        public string IdealNCM { get; set; }

        [Column("icms")]
        public decimal? ICMS { get; set; }

        [Column("icmsideal")]
        public decimal? IdealICMS { get; set; }

        [Column("pis")]
        public decimal? PIS { get; set; }

        [Column("pisideal")]
        public decimal? IdealPIS { get; set; }

        [Column("cofins")]
        public decimal? COFINS { get; set; }

        [Column("cofinsideal")]
        public decimal? IdealCOFINS { get; set; }

        [Column("ipi")]
        public decimal? IPI { get; set; }

        [Column("ipiideal")]
        public decimal? IdealIPI { get; set; }
    }
}
