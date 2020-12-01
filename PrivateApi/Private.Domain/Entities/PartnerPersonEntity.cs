using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Private.Domain.Entities
{
    [Table("pessoaparceiro")]
    public class PartnerPersonEntity : BaseEntity
    {
        [Key]
        [Column("idpessoaparceiro")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("idpessoa")]
        public Int64 IdPerson { get; set; }

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

        [MaxLength(1)]
        [Required]
        [Column("responsavelcobranca")]
        public string ChargeResponsible { get; set; }

        [Column("dataconfirmacadastro")]
        public DateTime? ConfirmationRegistrationDateTime { get; set; }

        [Column("hashconfirmacadastro")]
        public string ConfirmationRegistrationHash { get; set; }
    }
}
