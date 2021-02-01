using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("v_planoparceiro")]
    public class PartnerPlanViewEntity : BaseEntity
    {
        [Required]
        [Column("idplanocobrancaparceiro")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idpessoaparceiro")]
        public Int64 IdPartnerPerson { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("nomerazao")]
        public string ReasonName { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("fantasia")]
        public string Fantasy { get; set; }

        [Required]
        [MaxLength(1)]
        [Column("responsavelcobranca")]
        public string ChargeResponsible { get; set; }

        [MaxLength(50)]
        [Column("codigoacesso")]
        public string AccessCode { get; set; }

        [Required]
        [Column("dtainiciovigencia")]
        public DateTime StartOfTerm { get; set; }

        [Column("dtafimvigencia")]
        public DateTime? EndOfTerm { get; set; }

        [Required]
        [Column("idplanocobranca")]
        public Int64 IdBillingPlan { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("codplanocobranca")]
        public string BillingPlanCode { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("descplanocobranca")]
        public string BillingPlanDescription { get; set; }

        [Column("diasvigencia")]
        public Int64? EffectiveDays { get; set; }

        [Column("diascarencia")]
        public Int64? GraceDays { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("ciclocobranca")]
        public string BillingCycle { get; set; }

        [Required]
        [Column("valorvenda")]
        public double SaleValue { get; set; }

        [Column("valorparceiro")]
        public double? PartnerValue { get; set; }

        [Column("valorrevenda")]
        public double? ResaleValue { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("caracteristica")]
        public string Feature { get; set; }

        [Column("quantidade")]
        public double? Quantity { get; set; }

        [Required]
        [MaxLength(1)]
        [Column("ilimitado")]
        public string Unlimited { get; set; }

        [Required]
        [Column("idatributoplano")]
        public Int64 IdPlanAttribute { get; set; }

        [MaxLength(1)]
        [Column("visibilidade")]
        public string Visibility { get; set; }

        [Required]
        [MaxLength(1)]
        [Column("situacao")]
        public string Situation { get; set; }
    }
}
