using Private.Domain.DTOs.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface IReportService
    {
        ReportDto GetReport(string hash, string cnpj);
    }
}
