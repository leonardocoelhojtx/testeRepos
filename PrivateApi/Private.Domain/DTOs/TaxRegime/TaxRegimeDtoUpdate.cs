using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.TaxRegime
{
    public class TaxRegimeDtoUpdate
    {
        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [StringLength(150, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Status é campo obrigatório.")]
        [StringLength(1, ErrorMessage = "Status deve ter no máximo {1} caracteres.")]
        public string Status { get; set; }
    }
}
