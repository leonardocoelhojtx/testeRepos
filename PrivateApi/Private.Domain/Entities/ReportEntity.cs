using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("laudo")]
    public class ReportEntity : BaseEntity
    {
        [Required]
        [Column("idlaudo")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idsolicitantelaudo")]
        public Int64 IdReportRequest { get; set; }

        [Required]
        [Column("dtainclusao")]
        public DateTime InclusionDateTime { get; set; }

        [Column("qtdencontrado")]
        public Int64? QuantityFound { get; set; }

        [Column("qtdnaoencontrado")]
        public Int64? QuantityNotFound { get; set; }

        [Column("percencontrado")]
        public decimal? PercentageFound { get; set; }

        [Column("percnaoencontrado")]
        public decimal? PercentageNotFound { get; set; }

        [Column("qtdinconsistente")]
        public Int64? InconsistentAmount { get; set; }

        [Column("qtdinconsistentencm")]
        public Int64? InconsistentAmountNCM { get; set; }

        [MaxLength(200)]
        [Column("hash")]
        public string Hash { get; set; }
    }
}
