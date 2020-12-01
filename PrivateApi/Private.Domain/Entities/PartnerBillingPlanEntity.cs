using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("planocobrancaparceiro")]
    public class PartnerBillingPlanEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idplanocobrancaparceiro")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idplanocobranca")]
        public Int64 IdBillingPlan { get; set; }

        [Required]
        [Column("idpessoaparceiro")]
        public Int64 IdPartnerPerson { get; set; }

        [Required]
        [Column("situacao")]
        public string Situation { get; set; }

        [Required]
        [Column("datainiciovigencia")]
        public DateTime StartOfTerm { get; set; }

        [Column("datafimvigencia")]
        public DateTime? EndOfTerm { get; set; }

        [Required]
        [Column("valorvenda")]
        public double SaleValue { get; set; }

        [Column("valorparceiro")]
        public double? PartnerValue { get; set; }

        [Column("valorrevenda")]
        public double? ResaleValue { get; set; }

        [MaxLength(50)]
        [Column("codigoacesso")]
        public string AccessCode { get; set; }

        [MaxLength(1)]
        [Column("visibilidade")]
        public string Visibility { get; set; }

        [Required]
        [Column("idusuarioinclusao")]
        public Int64 InclusionIdUser { get; set; }

        [Required]
        [Column("dtainclusao")]
        public DateTime InclusionDateTime { get; set; }

        [Required]
        [Column("idusuarioultalteracao")]
        public Int64 ChangeIdUser { get; set; }

        [Required]
        [Column("dtaultimaalteracao")]
        public DateTime ChangeDateTime { get; set; }
    }
}
