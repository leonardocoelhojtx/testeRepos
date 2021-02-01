using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("v_cenariotributario")]
    public class TaxScenarioViewEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("idcenariotributario")]
        public override Int64 Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("descricao")]
        public string Description { get; set; }

        [Required]
        [Column("idregime")]
        public Int64 IdRegime { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("regimedescricao")]
        public string RegimeDescription { get; set; }

        [Required]
        [Column("idperfilorigem")]
        public Int64? IdOriginProfile { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("perfilorigemdescricao")]
        public string OriginProfileDescription { get; set; }

        [Required]
        [Column("idperfildestino")]
        public Int64? IdDestinationProfile { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("perfildestinodescricao")]
        public string DestinationProfileDescription { get; set; }

        [Required]
        [MaxLength(2)]
        [Column("uforigem")]
        public string OriginUF { get; set; }

        [Required]
        [MaxLength(2)]
        [Column("ufdestino")]
        public string DestinationUF { get; set; }

        [MaxLength(20)]
        [Column("cnae")]
        public string CNAE { get; set; }

        [Required]
        [Column("vigenciainicio")]
        public DateTime StartOfTerm { get; set; }

        [Column("vigenciafim")]
        public DateTime? EndOfTerm { get; set; }

        [Required]
        [Column("idnaturezaoperacao")]
        public Int64? IdOperationNature { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("naturezaoperacaodescricao")]
        public string OperationNatureDescription { get; set; }

        [Required]
        [MaxLength(1)]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("idusuarioinclusao")]
        public Int64 InclusionIdUser { get; set; }

        [MaxLength(200)]
        [Column("usuarioinclusaonome")]
        public string InclusionUserName { get; set; }

        [Required]
        [Column("dtainclusao")]
        public DateTime InclusionDateTime { get; set; }

        [Required]
        [Column("idusuarioultalteracao")]
        public Int64 ChangeIdUser { get; set; }

        [MaxLength(200)]
        [Column("usuarioalteracaonome")]
        public string ChangeUserName { get; set; }

        [Required]
        [Column("dtaultimaalteracao")]
        public DateTime ChangeDateTime { get; set; }
    }
}
