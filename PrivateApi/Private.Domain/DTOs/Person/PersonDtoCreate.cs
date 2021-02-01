using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.Person
{
    public class PersonDtoCreate
    {
        [Required(ErrorMessage = "Nome Razão é campo obrigatório.")]
        [StringLength(250, ErrorMessage = "Nome Razão deve ter no máximo {1} caracteres.")]
        public string ReasonName { get; set; }

        [Required(ErrorMessage = "Nome Fantasia é campo obrigatório.")]
        [StringLength(150, ErrorMessage = "Nome Fantasia deve ter no máximo {1} caracteres.")]
        public string Fantasy { get; set; }

        [Required(ErrorMessage = "CNPJ é campo obrigatório.")]
        public Int64 CpfCnpj { get; set; }

        public DateTime BirthDateTime { get; set; }

        [StringLength(250, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Telefone deve ter no máximo {1} caracteres.")]
        public string PrimaryPhone { get; set; }

        [StringLength(20, ErrorMessage = "Telefone Alternativo deve ter no máximo {1} caracteres.")]
        public string AlternativePhone { get; set; }

        [StringLength(1, ErrorMessage = "Pessoa física ou jurídica deve ter no máximo {1} caracteres.")]
        public string LegalPhysics { get; set; }

        [StringLength(100, ErrorMessage = "Nome Contato deve ter no máximo {1} caracteres.")]
        public string ContactName { get; set; }
    }
}
