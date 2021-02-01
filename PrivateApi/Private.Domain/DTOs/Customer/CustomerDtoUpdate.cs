using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.DTOs.Customer
{
    public class CustomerDtoUpdate : BaseDto
    {
        [Required(ErrorMessage = "Fantasia é campo obrigatório.")]
        [StringLength(150, ErrorMessage = "Fantasia deve ter no máximo {1} caracteres.")]
        public string Fantasy { get; set; }

        [StringLength(250, MinimumLength = 0, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Telefone principal deve ter no máximo {1} caracteres.")]
        public string PrimaryPhone { get; set; }

        [StringLength(20, ErrorMessage = "Telefone alternativo deve ter no máximo {1} caracteres.")]
        public string AlternativePhone { get; set; }
    }
}
