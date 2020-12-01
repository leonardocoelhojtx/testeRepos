using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.TaxScenario
{
    public class TaxScenarioDtoInsert
    {
        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [StringLength(200, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Id Regime é campo obrigatório.")]
        public Int64 IdRegime { get; set; }

        [Required(ErrorMessage = "Id Perfil Origem é campo obrigatório.")]
        public Int64 IdOriginProfile { get; set; }

        [Required(ErrorMessage = "Id Perfil Destino é campo obrigatório.")]
        public Int64 IdDestinationProfile { get; set; }

        [Required(ErrorMessage = "UF de Origem é campo obrigatório.")]
        [StringLength(2, ErrorMessage = "UF de Origem deve ter no máximo {1} caracteres.")]
        public string OriginUF { get; set; }

        [Required(ErrorMessage = "UF de Destino é campo obrigatório.")]
        [StringLength(2, ErrorMessage = "UF de Destino deve ter no máximo {1} caracteres.")]
        public string DestinationUF { get; set; }

        [StringLength(20, ErrorMessage = "CNAE deve ter no máximo {1} caracteres.")]
        public string CNAE { get; set; }

        [Required(ErrorMessage = "Início da Vigência é campo obrigatório.")]
        public DateTime StartOfTerm { get; set; }

        public DateTime? EndOfTerm { get; set; }

        [Required(ErrorMessage = "Id Natureza da Operação é campo obrigatório.")]
        public Int64 IdOperationNature { get; set; }

        [Required(ErrorMessage = "Status é campo obrigatório.")]
        [StringLength(1, ErrorMessage = "Status deve ter no máximo {1} caracteres.")]
        public string Status { get; set; }
    }
}
