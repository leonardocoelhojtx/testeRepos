using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.SalesPlan
{
    public class BillingPlanDtoInsert
    {
        [Required(ErrorMessage = "Código é campo obrigatório.")]
        [StringLength(15, ErrorMessage = "Código deve ter no máximo {1} caracteres.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [StringLength(250, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [StringLength(1, ErrorMessage = "Situação deve ter no máximo {1} caracteres.")]
        public string Situation { get; set; }

        [Required(ErrorMessage = "Data início da vigência é campo obrigatório.")]
        public DateTime StartOfTerm { get; set; }
        public DateTime EndOfTerm { get; set; }

        [Required(ErrorMessage = "Valor é campo obrigatório.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Dias de vigência é campo obrigatório.")]
        public Int64 EffectiveDays { get; set; }

        [Required(ErrorMessage = "Dias de carência é campo obrigatório.")]
        public Int64 GraceDays { get; set; }

        [Required(ErrorMessage = "Ciclo de cobrança é campo obrigatório.")]
        [StringLength(10, ErrorMessage = "Ciclo de cobrança deve ter no máximo {1} caracteres.")]
        public string BillingCycle { get; set; }

        [Required(ErrorMessage = "Lista de atributos é campo obrigatório.")]
        public List<PlanAttributeDtoInsert> Attributes { get; set; }
    }
}
