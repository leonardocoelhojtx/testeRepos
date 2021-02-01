using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Repositories
{
    public interface IPersonAddressRepositoryReadOnly : IRepositoryReadOnly<PersonAddressEntity>
    {
        Task<List<PersonAddressEntity>> SelectAddressByIdPerson(Int64 idPerson);
    }
}
