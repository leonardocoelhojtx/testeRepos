using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.Partner
{
    public class PartnerPersonDtoInsert
    {
        [Required(ErrorMessage = "Status é campo obrigatório")]
        [StringLength(1, ErrorMessage = "Status deve ter no máximo {1} caracteres.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Responsável Cobrança é campo obrigatório")]
        [StringLength(1, ErrorMessage = "Responsável Cobrança deve ter no máximo {1} caracteres.")]
        public string ChargeResponsible { get; set; }
    }
}
