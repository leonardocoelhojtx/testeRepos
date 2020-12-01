using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("cenariotributario")]
    public class TaxScenarioEntity : BaseEntity
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
        [Column("idperfilorigem")]
        public Int64? IdOriginProfile { get; set; }

        [Required]
        [Column("idperfildestino")]
        public Int64? IdDestinationProfile { get; set; }

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
        [MaxLength(1)]
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
    }
}
