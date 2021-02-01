using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Repositories
{
    public interface IUserRepositoryReadOnly : IRepositoryReadOnly<UserViewEntity>
    {
        Task<List<UserViewEntity>> GetUsers(Boolean status);
        Task<UserViewEntity> GetUserByEmail(string email);
    }
}
