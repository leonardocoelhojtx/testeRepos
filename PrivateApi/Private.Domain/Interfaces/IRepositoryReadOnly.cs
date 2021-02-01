using Microsoft.EntityFrameworkCore;
using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces
{
    public interface IRepositoryReadOnly<T> where T : BaseEntity
    {
        Task<T> SelectAsync(Int64 id, bool eagerLoading = false);
        Task<IEnumerable<T>> SelectAsync(bool eagerLoading = false);
        Task<bool> ExistsAsync(Int64 id);
    }
}
