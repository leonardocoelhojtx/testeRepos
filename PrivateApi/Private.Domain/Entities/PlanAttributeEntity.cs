using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Private.Domain.Entities
{
    [Table("atributoplano")]
    public class PlanAttributeEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idatributoplano")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idatributocobranca")]
        public Int64 IdBillingAttribute { get; set; }

        [Required]
        [Column("idplanocobranca")]
        public Int64 IdBillingPlan { get; set; }

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

        [Column("quantidade")]
        public double Quantity { get; set; }
    }
}
