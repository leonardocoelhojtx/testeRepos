using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("usuarioparceiro")]
    public class PartnerUserEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idusuarioparceiro")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idpessoaparceiro")]
        public Int64 IdPartner { get; set; }

        [Required]
        [Column("idusuario")]
        public Int64 IdUser { get; set; }

        [Required]
        [MaxLength(1)]
        [Column("situacao")]
        public string Situation { get; set; }

        [Column("idusuarioinclusao")]
        public Int64 InclusionIdUser { get; set; }

        [Column("dtainclusao")]
        public DateTime InclusionDateTime { get; set; }

        [Column("idusuarioultalteracao")]
        public Int64? ChangeIdUser { get; set; }

        [Column("dtaultimaalteracao")]
        public DateTime? ChangeDateTime { get; set; }
    }
}
