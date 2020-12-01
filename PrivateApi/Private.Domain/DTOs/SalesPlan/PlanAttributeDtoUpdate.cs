using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.SalesPlan
{
    public class PlanAttributeDtoUpdate
    {
        [Required(ErrorMessage = "Quantidade é campo obrigatório.")]
        public double Quantity { get; set; }
    }
}
