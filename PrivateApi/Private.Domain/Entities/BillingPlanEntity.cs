using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Private.Domain.Entities
{
    [Table("planocobranca")]
    public class BillingPlanEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idplanocobranca")]
        public override Int64 Id { get; set; }

        [MaxLength(15)]
        [Required]
        [Column("codigo")]
        public string Code { get; set; }

        [MaxLength(250)]
        [Required]
        [Column("descricao")]
        public string Description { get; set; }

        [MaxLength(1)]
        [Required]
        [Column("situacao")]
        public string Situation { get; set; }

        [Required]
        [Column("datainiciovigencia")]
        public DateTime StartOfTerm { get; set; }

        [Column("datafimvigencia")]
        public DateTime? EndOfTerm { get; set; }

        [Column("valor")]
        public double Value { get; set; }

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

        [Column("diasvigencia")]
        public Int64? EffectiveDays { get; set; }

        [Column("diascarencia")]
        public Int64? GraceDays { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("ciclocobranca")]
        public string BillingCycle { get; set; }
    }
}
