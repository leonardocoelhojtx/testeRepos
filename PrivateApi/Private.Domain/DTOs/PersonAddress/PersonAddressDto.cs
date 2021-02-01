using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.PersonAddress
{
    public class PersonAddressDto
    {
        public Int64 Id { get; set; }
        public Int64 IdPerson { get; set; }    
        public Int64 Type { get; set; }
        public Int64? Cep { get; set; }
        public string Street { get; set; }
        public Int64? Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
