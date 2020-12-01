using Private.Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers(Boolean status);
        Task<UserDto> GetUserByEmail(string email);
    }
}
