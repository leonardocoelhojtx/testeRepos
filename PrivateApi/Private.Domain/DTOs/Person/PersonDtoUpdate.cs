using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.Person
{
    public class PersonDtoUpdate
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "Fantasy é campo obrigatório")]
        [StringLength(150, ErrorMessage = "Fantasy deve ter no máximo {1} caracteres.")]
        public string Fantasy { get; set; }

        [StringLength(250, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "PrimaryPhone deve ter no máximo {1} caracteres.")]
        public string PrimaryPhone { get; set; }

        [StringLength(20, ErrorMessage = "AlternativePhone deve ter no máximo {1} caracteres.")]
        public string AlternativePhone { get; set; }

        //public Int64 ChangeIdUser { get; set; }
        //public DateTime? ChangeDateTime { get; set; }
    }
}