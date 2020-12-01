using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("pessoaendereco")]
    public class PersonAddressEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idpessoaendereco")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idpessoa")]
        public Int64 IdPerson { get; set; }

        [Required]
        [Column("tipo")]
        public Int64 type { get; set; }

        [Column("cep")]
        public Int64? cep { get; set; }

        [MaxLength(250)]
        [Column("logradouro")]
        public string street { get; set; }

        [MaxLength(30)]
        [Column("logradouronro")]
        public string number { get; set; }

        [MaxLength(100)]
        [Column("complemento")]
        public string complement { get; set; }

        [MaxLength(100)]
        [Column("bairro")]
        public string neighborhood { get; set; }

        [MaxLength(150)]
        [Column("cidade")]
        public string city { get; set; }

        [MaxLength(2)]
        [Column("estado")]
        public string state { get; set; }

        [MaxLength(150)]
        [Column("pais")]
        public string country { get; set; }

        [Required]
        [Column("idusuarioinclusao")]
        public Int64 inclusionIdUser { get; set; }

        [Required]
        [Column("dtainclusao")]
        public DateTime inclusionDateTime { get; set; }

        [Required]
        [Column("idusuarioultalteracao")]
        public Int64 changeIdUser { get; set; }

        [Required]
        [Column("dtaultimaalteracao")]
        public DateTime changeDateTime { get; set; }
    }
}
