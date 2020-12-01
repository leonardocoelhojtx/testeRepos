using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Private.Domain.DTOs.PersonAddress
{
    public class PersonAddressDtoUpdate
    {
        //public Int64 type { get; set; }        
        public Int64? Cep { get; set; }

        [StringLength(250, ErrorMessage = "Logradouro deve ter no máximo {1} caracteres.")]
        public string Street { get; set; }
        public string Number { get; set; }

        [StringLength(100, ErrorMessage = "Complemento deve ter no máximo {1} caracteres.")]
        public string Complement { get; set; }

        [StringLength(100, ErrorMessage = "Neighborhood deve ter no máximo {1} caracteres.")]
        public string Neighborhood { get; set; }

        [StringLength(150, ErrorMessage = "Cidade deve ter no máximo {1} caracteres.")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "Estado deve ter no máximo {1} caracteres.")]
        public string State { get; set; }
    }
}
