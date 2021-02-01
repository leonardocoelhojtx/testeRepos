using Private.Domain.DTOs.QueryLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface IQueryLogService
    {
        Task<IEnumerable<QueryLogDto>> GetAllByFilters(string listType, string initialDate, string endDate, Int64? idCustomer, Int64? idPartner, Int64? idProduct, string productDescription);
    }
}
