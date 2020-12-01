using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("usuariocliente")]
    public class CustomerUserEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idusuariocliente")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idpessoacliente")]
        public Int64 IdCustomer { get; set; }

        [Required]
        [Column("idusuario")]
        public Int64 IdUser { get; set; }

        [Required]
        [MaxLength(1)]
        [Column("situacao")]
        public string Situation { get; set; }

        [Column("idusuarioultalteracao")]
        public Int64? ChangeIdUser { get; set; }

        [Column("dtaultimaalteracao")]
        public DateTime? ChangeDateTime { get; set; }
    }
}
