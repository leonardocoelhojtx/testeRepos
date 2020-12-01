using Microsoft.EntityFrameworkCore;
using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Data.Repository
{
    public class UserRepositoryReadOnly : BaseRepositoryReadOnly<UserViewEntity>, IUserRepositoryReadOnly
    {
        private readonly PrivateApiReadOnlyContext _context;
        private DbSet<UserViewEntity> _dataset;
        public UserRepositoryReadOnly(PrivateApiReadOnlyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<UserViewEntity>();
        }

        public async Task<List<UserViewEntity>> GetUsers(Boolean status)
        {
            try
            {
                return await _context.Users.AsNoTracking().Where(x => x.Status.Equals(status)).ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UserViewEntity> GetUserByEmail(string email)
        {
            try
            {
                return await _context.Users.AsNoTracking()
                    .Where(x => x.Email.ToLower().Equals(email.ToLower())).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
