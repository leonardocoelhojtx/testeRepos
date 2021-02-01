using Microsoft.EntityFrameworkCore;
using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Private.Data.Repository
{
    public class PersonAddressRepositoryReadOnly : BaseRepository<PersonAddressEntity>, IPersonAddressRepositoryReadOnly
    {
        private DbSet<PersonAddressEntity> _dataset;
        private readonly PrivateApiContext _context;

        public PersonAddressRepositoryReadOnly(PrivateApiContext context) : base(context)
        {
            _context = context;
            _dataset = context.Set<PersonAddressEntity>();
        }

        public async Task<List<PersonAddressEntity>> SelectAddressByIdPerson(Int64 idPerson)
        {
            try
            {
                return await _context.PersonAddress.AsNoTracking().Where(x => x.IdPerson == idPerson).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
