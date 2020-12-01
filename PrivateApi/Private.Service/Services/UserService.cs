using AutoMapper;
using Private.Domain.DTOs.User;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryReadOnly _userRepositoryReadOnly;
        private readonly IMapper _mapper;
        public UserService(
            IUserRepositoryReadOnly userRepositoryReadOnly,
            IMapper mapper)
        {
            _userRepositoryReadOnly = userRepositoryReadOnly;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var userEntity = await _userRepositoryReadOnly.GetUserByEmail(email);
            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<IEnumerable<UserDto>> GetUsers(Boolean status)
        {
            var listUserEntity = await _userRepositoryReadOnly.GetUsers(status);
            return _mapper.Map<List<UserDto>>(listUserEntity);
        }
    }
}
