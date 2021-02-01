using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Repositories
{
    public interface ICustomerUserRepository : IRepository<CustomerUserEntity>
    {
        Task UpdateCustomerUserSituationAsync(Int64 idCustomer, Int64 idUser, string situation);
    }
}
