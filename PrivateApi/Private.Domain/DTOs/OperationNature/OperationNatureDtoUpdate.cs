using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.OperationNature
{
    public class OperationNatureDtoUpdate
    {
        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [StringLength(250, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Status é campo obrigatório.")]
        [StringLength(1, ErrorMessage = "Status deve ter no máximo {1} caracteres.")]
        public string Status { get; set; }
    }
}
