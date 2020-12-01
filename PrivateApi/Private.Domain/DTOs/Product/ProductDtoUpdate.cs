using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.Product
{
    public class ProductDtoUpdate
    {
        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [StringLength(250, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Descrição Reduzida é campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Descrição Reduzida deve ter no máximo {1} caracteres.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Status é campo obrigatório.")]
        [StringLength(1, ErrorMessage = "Status deve ter no máximo {1} caracteres.")]
        public string Status { get; set; }

        [StringLength(8, ErrorMessage = "NCM deve ter no máximo {1} caracteres.")]
        public string NCM { get; set; }

        [Required(ErrorMessage = "EAN é campo obrigatório.")]
        [StringLength(20, ErrorMessage = "EAN deve ter no máximo {1} caracteres.")]
        public string EAN { get; set; }
    }
}
