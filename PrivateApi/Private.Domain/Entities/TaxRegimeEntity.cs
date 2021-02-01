using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("regimetributario")]
    public class TaxRegimeEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idregimetributario")]
        public override Int64 Id { get; set; }

        [MaxLength(150)]
        [Required]
        [Column("descricao")]
        public string Description { get; set; }

        [MaxLength(1)]
        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("dtainclusao")]
        public DateTime InclusionDateTime { get; set; }

        [Required]
        [Column("idusuarioinclusao")]
        public Int64 InclusionIdUser { get; set; }

        [Required]
        [Column("dtaultimaalteracao")]
        public DateTime ChangeDateTime { get; set; }

        [Required]
        [Column("idusuarioultimaalteracao")]
        public Int64 ChangeIdUser { get; set; }
    }
}
