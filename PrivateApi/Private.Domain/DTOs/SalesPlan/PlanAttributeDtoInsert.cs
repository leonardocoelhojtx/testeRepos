using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.SalesPlan
{
    public class PlanAttributeDtoInsert
    {
        [Required(ErrorMessage = "Identificador do atributo da cobrança é campo obrigatório.")]
        public Int64 IdBillingAttribute { get; set; }

        [Required(ErrorMessage = "Quantidade é campo obrigatório.")]
        public double Quantity { get; set; }
    }
}
