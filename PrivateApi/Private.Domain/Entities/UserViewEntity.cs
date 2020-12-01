using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.Entities
{
    [Table("v_usuario")]
    public class UserViewEntity : BaseEntity
    {
        [Key]
        [Required]
        [Column("id")]
        public override Int64 Id { get; set; }

        [MaxLength(200)]
        [Column("email")]
        public string Email { get; set; }

        [MaxLength(200)]
        [Column("nomecompleto")]
        public string FullName { get; set; }

        [Required]
        [Column("status")]
        public Boolean Status { get; set; }
    }
}
