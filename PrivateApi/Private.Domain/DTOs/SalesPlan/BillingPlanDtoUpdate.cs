using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.SalesPlan
{
    public class BillingPlanDtoUpdate
    {
        [StringLength(250, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [StringLength(1, ErrorMessage = "Situação deve ter no máximo {1} caracteres.")]
        public string Situation { get; set; }
        public DateTime? StartOfTerm { get; set; }
        public DateTime? EndOfTerm { get; set; }
        public double? Value { get; set; }
        public Int64? EffectiveDays { get; set; }
        public Int64? GraceDays { get; set; }

        [StringLength(10, ErrorMessage = "Ciclo de cobrança deve ter no máximo {1} caracteres.")]
        public string BillingCycle { get; set; }
    }
}
