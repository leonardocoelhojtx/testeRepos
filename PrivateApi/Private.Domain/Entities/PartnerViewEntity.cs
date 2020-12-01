using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("v_parceiro")]
    public class PartnerViewEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idpessoaparceiro")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idpessoa")]
        public Int64 IdPerson { get; set; }

        [MaxLength(250), Required]
        [Column("nomerazao")]
        public string ReasonName { get; set; }

        [MaxLength(150), Required]
        [Column("fantasia")]
        public string Fantasy { get; set; }

        [Required]
        [Column("cpfcnpj")]
        public Int64 CpfCnpj { get; set; }

        [MaxLength(250)]
        [Column("email")]
        public string Email { get; set; }

        [MaxLength(20)]
        [Column("telefone")]
        public string PrimaryPhone { get; set; }

        [MaxLength(20)]
        [Column("telefonealt")]
        public string AlternativePhone { get; set; }

        [MaxLength(1), Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("idusuarioinclusao")]
        public Int64 InclusionIdUser { get; set; }

        [Column("nomeusuarioinclusao")]
        public string InclusionUserName { get; set; }

        [Required]
        [Column("dtainclusao")]
        public DateTime InclusionDateTime { get; set; }

        [Column("idusuarioultalteracao")]
        public Int64 ChangeIdUser { get; set; }

        [Column("nomeusuarioultimaalteracao")]
        public string ChangeUserName { get; set; }

        [Column("dtaultimaalteracao")]
        public DateTime ChangeDateTime { get; set; }

        [MaxLength(250)]
        [Column("hash")]
        public string Hash { get; set; }

        [MaxLength(100)]
        [Column("contatonome")]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(1)]
        [Column("responsavelcobranca")]
        public string chargeResponsible { get; set; }
    }
}
