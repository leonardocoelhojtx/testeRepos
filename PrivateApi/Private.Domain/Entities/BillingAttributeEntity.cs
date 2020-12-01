using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("atributocobranca")]
    public class BillingAttributeEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idatributocobranca")]
        public override Int64 Id { get; set; }

        [MaxLength(25)]
        [Required]
        [Column("atributo")]
        public string Attribute { get; set; }

        [MaxLength(250)]
        [Required]
        [Column("valor")]
        public string Value { get; set; }

        [MaxLength(1)]
        [Required]
        [Column("status")]
        public string Status { get; set; }

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
