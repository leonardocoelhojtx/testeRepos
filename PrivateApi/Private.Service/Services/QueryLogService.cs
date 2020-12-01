using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Private.Domain.DTOs.QueryLog;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Private.Service.Services
{
    public class QueryLogService : IQueryLogService
    {
        private readonly IQueryLogRepositoryReadOnly _queryLogRepoReadOnly;
        private readonly IMapper _mapper;
        public QueryLogService(
            IQueryLogRepositoryReadOnly queryLogRepoReadOnly,
            IMapper mapper
            )
        {
            _queryLogRepoReadOnly = queryLogRepoReadOnly;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QueryLogDto>> GetAllByFilters(string listType, string initialDate, string endDate, Int64? idCustomer, Int64? idPartner, Int64? idProduct, string productDescription)
        {
            var query = _queryLogRepoReadOnly.SelectQueryLogs();

            if (!String.IsNullOrEmpty(listType))
            {
                var types = listType.Split(",").Select(Int64.Parse);
                query = query.Where(x => types.Contains(x.Type));
            }

            if (!String.IsNullOrEmpty(initialDate))
            {
                var initialDateTime = Convert.ToDateTime(initialDate);
                query = query.Where(x => x.QueryDateTime >= initialDateTime);
            }

            if (!String.IsNullOrEmpty(endDate))
            {
                var endDateTime = Convert.ToDateTime(endDate);
                query = query.Where(x => x.QueryDateTime <= endDateTime);
            }

            if (idCustomer != null && idCustomer > 0)
            {
                query = query.Where(x => x.IdCustomer == idCustomer);
            }

            if (idPartner != null && idPartner > 0)
            {
                query = query.Where(x => x.IdPartner == idPartner);
            }

            if (idProduct != null && idProduct > 0)
            {
                query = query.Where(x => x.IdProduct == idProduct);
            }

            if (!String.IsNullOrEmpty(productDescription))
            {
                query = query.Where(x => x.ProductDescription.ToUpper().Contains(productDescription.ToUpper()) 
                || x.ProductNcm.ToUpper().Contains(productDescription.ToUpper())
                || x.ProductGtin.ToUpper().Contains(productDescription.ToUpper()));
            }

            var listQueryLog = await query.OrderByDescending(x => x.QueryDateTime).ToListAsync();

            return _mapper.Map<List<QueryLogDto>>(listQueryLog);
        }
    }
}
