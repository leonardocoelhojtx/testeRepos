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
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PrivateApiContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(PrivateApiContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Int64 id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                // TODO: definir se é necessário autoincremento aqui ou no direto no BD
                //if (item.Id == Guid.Empty)
                //{
                //    item.Id = Guid.NewGuid();
                //}

                // item.CreatedAt = DateTime.UtcNow;
                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return item;
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

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null)
                {
                    return null;
                }

                // item.UpdatedAt = DateTime.UtcNow;
                // item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return item;
        }
    }
}
