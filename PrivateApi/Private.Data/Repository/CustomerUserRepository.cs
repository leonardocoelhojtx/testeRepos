using Microsoft.EntityFrameworkCore;
using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Data.Repository
{
    public class CustomerUserRepository : BaseRepository<CustomerUserEntity>, ICustomerUserRepository
    {
        private readonly PrivateApiContext _context;
        private DbSet<CustomerUserEntity> _dataset;
        public CustomerUserRepository(PrivateApiContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<CustomerUserEntity>();
        }

        public async Task UpdateCustomerUserSituationAsync(Int64 idCustomer, Int64 idUser, string situation)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.IdCustomer.Equals(idCustomer) && p.IdUser.Equals(idUser));

                if (result != null)
                {
                    result.Situation = situation.ToUpper();
                    result.ChangeIdUser = idUser;
                    result.ChangeDateTime = DateTime.Now;

                    _context.Entry(result).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
