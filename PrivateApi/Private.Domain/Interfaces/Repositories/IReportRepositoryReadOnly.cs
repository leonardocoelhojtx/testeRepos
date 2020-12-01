using Private.Domain.DTOs.Report;
using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Repositories
{
    public interface IReportRepositoryReadOnly : IRepositoryReadOnly<ReportEntity>
    {
        ReportDto GetReport(string hash, string cnpj);
        ReportEntity GetReportByHash(string hash);
    }
}
