using Private.Domain.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Domain.DTOs.Customer
{
    public class CustomerDtoCreateRequest
    {
        public string CodigoAcesso { get; set; }
        public Int64 CpfCnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime DataNascFundacao { get; set; }
        public string Email { get; set; }
        public string TelefonePrincipal { get; set; }
        public string TelefoneAlternativo { get; set; }
        public CustomerAddressDtoCreate Endereco { get; set; }
    }

    public class CustomerAddressDtoCreate
    {
        public Int64 Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
