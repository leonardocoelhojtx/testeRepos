using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.PartnerPlan
{
    public class PartnerBillingPlanDtoInsert
    {
        [Required(ErrorMessage = "Identificador do plano de cobrança é campo obrigatório.")]
        public Int64 IdBillingPlan { get; set; }

        [Required(ErrorMessage = "Identificador do parceiro é campo obrigatório.")]
        public Int64 IdPartnerPerson { get; set; }

        [Required(ErrorMessage = "Data de início da vigência é campo obrigatório.")]
        public DateTime StartOfTerm { get; set; }

        [Required(ErrorMessage = "Data de fim da vigência é campo obrigatório.")]
        public DateTime EndOfTerm { get; set; }

        [Required(ErrorMessage = "Valor de venda é campo obrigatório.")]
        public double SaleValue { get; set; }

        [Required(ErrorMessage = "Valor do parceiro é campo obrigatório.")]
        public double PartnerValue { get; set; }

        [Required(ErrorMessage = "Valor de revenda é campo obrigatório.")]
        public double ResaleValue { get; set; }

        [Required(ErrorMessage = "Código de acesso é campo obrigatório.")]
        public string AccessCode { get; set; }

        public string Situation { get; set; }

        public string Visibility { get; set; }
    }
}
