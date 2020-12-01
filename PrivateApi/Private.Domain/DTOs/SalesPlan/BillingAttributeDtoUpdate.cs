using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.SalesPlan
{
    public class BillingAttributeDtoUpdate
    {
        [StringLength(25, ErrorMessage = "Atributo deve ter no máximo {1} caracteres.")]
        public string Attribute { get; set; }

        [StringLength(250, ErrorMessage = "Valor deve ter no máximo {1} caracteres.")]
        public string Value { get; set; }

        [StringLength(1, ErrorMessage = "Status deve ter no máximo {1} caracteres.")]
        public string Status { get; set; }
    }
}
