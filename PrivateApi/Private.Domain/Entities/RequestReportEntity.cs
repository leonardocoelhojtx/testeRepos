using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("solicitantelaudo")]
    public class RequestReportEntity : BaseEntity
    {
        [Required]
        [Column("idsolicitantelaudo")]
        public override Int64 Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("nome")]
        public string Name { get; set; }

        [Required]
        [Column("cnpj")]
        public Int64 CNPJ { get; set; }

        [MaxLength(3)]
        [Column("telefoneddd")]
        public string PhoneDDD { get; set; }

        [MaxLength(10)]
        [Column("telefonenro")]
        public string PhoneNumber { get; set; }
    }
}
