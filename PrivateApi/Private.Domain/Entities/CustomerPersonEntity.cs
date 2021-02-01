using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("pessoacliente")]
    public class CustomerPersonEntity : BaseEntity
    {
        [Key]
        [Column("idpessoacliente")]
        public override Int64 Id { get; set; }

        [Column("idusuarioultalteracao")]
        public Int64 ChangeIdUser { get; set; }

        [Column("dtaultimaalteracao")]
        public DateTime ChangeDateTime { get; set; }
    }
}
