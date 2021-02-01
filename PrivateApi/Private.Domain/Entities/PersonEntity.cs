using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("pessoa")]
    public class PersonEntity : BaseEntity
    {
        [Key]
        [Column("idpessoa")]
        public override Int64 Id { get; set; }

        [MaxLength(250), Required]
        [Column("nomerazao")]
        public string ReasonName { get; set; }

        [MaxLength(150), Required]
        [Column("fantasia")]
        public string Fantasy { get; set; }

        [Required]
        [Column("cpfcnpj")]
        public Int64 CpfCnpj { get; set; }

        [Column("dtanascimento")]
        public DateTime BirthDateTime { get; set; }

        [MaxLength(250)]
        [Column("email")]
        public string Email { get; set; }

        [MaxLength(20)]
        [Column("telefone")]
        public string PrimaryPhone { get; set; }
        
        [Column("enderecocep")]
        public Int64? Cep { get; set; }

        [MaxLength(250)]
        [Column("enderecologradouro")]
        public string Street { get; set; }

        [Column("enderecologradouronro")]
        public Int64? Number { get; set; }

        [MaxLength(150)]
        [Column("enderecocidade")]
        public string City { get; set; }

        [MaxLength(2)]
        [Column("enderecoestado")]
        public string Uf { get; set; }

        [MaxLength(150)]
        [Column("enderecopais")]
        public string Country { get; set; }

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

        [MaxLength(20)]
        [Column("telefonealt")]
        public string AlternativePhone { get; set; }

        [MaxLength(1)]
        [Column("fisicajuridica")]
        public string LegalPhysics { get; set; }

        [MaxLength(250)]
        [Column("bairro")]
        public string Neighborhood { get; set; }

        [MaxLength(100)]
        [Column("contatonome")]
        public string ContactName { get; set; }
    }
}
