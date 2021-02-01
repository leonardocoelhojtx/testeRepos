using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.Person
{
    public class PersonDto
    {
        public Int64 Id { get; set; }
        public string NomeRazao { get; set; }
        public string Fantasia { get; set; }
        public string FisicaJuridica { get; set; }
        public Int64 CpfCnpj { get; set; }
    }
}
