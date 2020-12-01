using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("v_usuarioparceiro")]
    public class PartnerUserViewEntity : BaseEntity
    {
        [Required]
        [Column("idpessoaparceiro")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idusuario")]
        public Int64 IdUser { get; set; }

        [MaxLength(200)]
        [Column("nomecompleto")]
        public string FullName { get; set; }
        
        [MaxLength(200)]
        [Column("email")]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(1)]
        [Column("situacao")]
        public string Situation { get; set; }

        [Required]
        [Column("dtainclusao")]
        public DateTime InclusionDateTime { get; set; }
    }
}
