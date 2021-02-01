using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("v_logconsulta")]
    public class QueryLogViewEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idlogconsulta")]
        public override Int64 Id { get; set; }

        [Required]
        [Column("tipo")]
        public Int64 Type { get; set; }

        [Required]
        [Column("dtaconsulta")]
        public DateTime QueryDateTime { get; set; }

        [MaxLength(200)]
        [Column("descricao")]
        public string Description { get; set; }

        [Required]
        [Column("dtainclusao")]
        public DateTime InclusionDateTime { get; set; }

        [Column("idpessoacliente")]
        public Int64? IdCustomer { get; set; }

        [MaxLength(250)]
        [Column("nomerazaocliente")]
        public string CustomerReasonName { get; set; }

        [MaxLength(150)]
        [Column("fantasiacliente")]
        public string CustomerFantasy { get; set; }

        [Column("idpessoaparceiro")]
        public Int64? IdPartner { get; set; }

        [MaxLength(250)]
        [Column("nomerazaoparceiro")]
        public string PartnerReasonName { get; set; }

        [MaxLength(150)]
        [Column("fantasiaparceiro")]
        public string PartnerFantasy { get; set; }

        [Required]
        [MaxLength(2000)]
        [Column("url")]
        public string URL { get; set; }

        [Column("ponteiro")]
        public Int64? Pointer { get; set; }

        [Column("idproduto")]
        public Int64? IdProduct { get; set; }

        [MaxLength(250)]
        [Column("descricaoproduto")]
        public string ProductDescription { get; set; }

        [MaxLength(8)]
        [Column("ncmproduto")]
        public string ProductNcm { get; set; }

        [MaxLength(20)]
        [Column("gtinproduto")]
        public string ProductGtin { get; set; }


        [Required]
        [Column("idusuarioinclusao")]
        public Int64 InclusionIdUser { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("nomeusuarioinclusao")]
        public string InclusionUserName { get; set; }

        [Required]
        [Column("dtaultimaalteracao")]
        public DateTime ChangeDateTime { get; set; }

        [Required]
        [Column("idusuarioultalteracao")]
        public Int64 ChangeIdUser { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("nomeusuarioultalteracao")]
        public string ChangeUserName { get; set; }
    }
}
