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
    public class QueryLogRepositoryReadOnly : BaseRepositoryReadOnly<QueryLogViewEntity>, IQueryLogRepositoryReadOnly
    {
        private DbSet<QueryLogViewEntity> _dataset;
        private readonly PrivateApiReadOnlyContext _context;

        public QueryLogRepositoryReadOnly(PrivateApiReadOnlyContext context) : base(context)
        {
            _context = context;
            _dataset = context.Set<QueryLogViewEntity>();
        }

        public IQueryable<QueryLogViewEntity> SelectQueryLogs()
        {
            try
            {
                return _context.QueryLogs;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
