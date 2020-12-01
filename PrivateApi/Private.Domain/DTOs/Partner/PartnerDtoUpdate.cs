using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Private.Domain.DTOs.Partner
{
    public class PartnerDtoUpdate : BaseDto
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

        [StringLength(100, ErrorMessage = "Nome do contato deve ter no máximo {1} caracteres.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Responsável cobrança é campo obrigatório.")]
        [StringLength(1, ErrorMessage = "Responsável cobrança deve ter no máximo {1} caracteres.")]
        public string ChargeResponsible { get; set; }
    }
}
