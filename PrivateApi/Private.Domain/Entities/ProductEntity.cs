using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("produto")]
    public class ProductEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idproduto")]
        public override Int64 Id { get; set; }

        [MaxLength(250)]
        [Required]
        [Column("descricao")]
        public string Description { get; set; }

        [MaxLength(50)]
        [Required]
        [Column("descricaoreduzida")]
        public string ShortDescription { get; set; }

        [MaxLength(1)]
        [Required]
        [Column("status")]
        public string Status { get; set; }

        [MaxLength(8)]
        [Column("ncm")]
        public string NCM { get; set; }

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

        [MaxLength(20)]
        [Required]
        [Column("EAN")]
        public string EAN { get; set; }
    }
}
