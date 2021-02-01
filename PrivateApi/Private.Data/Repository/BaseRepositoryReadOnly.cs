using Microsoft.EntityFrameworkCore;
using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Data.Repository
{
    public class BaseRepositoryReadOnly<T> : IRepositoryReadOnly<T> where T : BaseEntity
    {
        private readonly PrivateApiReadOnlyContext _context;
        private DbSet<T> _dataset;

        public BaseRepositoryReadOnly(PrivateApiReadOnlyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> ExistsAsync(Int64 id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Int64 id, bool eagerLoading = false)
        {
            try
            {
                var query = _dataset.AsQueryable();

                if (eagerLoading)
                {
                    foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
                    {
                        query = query.Include(property.Name);
                    }
                }

                return await query.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync(bool eagerLoading = false)
        {
            try
            {
                var query = _dataset.AsQueryable();

                if(eagerLoading)
                {
                    foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
                    {
                        query = query.Include(property.Name);
                    }
                }

                return await query.ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
