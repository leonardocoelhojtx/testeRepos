using Private.Domain.DTOs.Customer;
using Private.Domain.DTOs.Person;
using Private.Domain.DTOs.PersonAddress;
using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> Get(Int64 id);
        Task<IEnumerable<CustomerUserDto>> GetCustomerUsers(Int64 id);
        Task PutPersonAndCustomer(CustomerDtoUpdate customer);
        Task<PersonAddressEntity> PutPartnerAddress(Int64 idPersonAddress, Int64 idCustomer, Int64 idUser, PersonAddressDtoUpdate personAddress);
        Task PutCustomerUserSituation(Int64 idCustomer, Int64 idUser, string situation);
        Task PostCustomerUser(Int64 idCustomer, Int64 idUser, Int64 idUserLogged);
    }
}
