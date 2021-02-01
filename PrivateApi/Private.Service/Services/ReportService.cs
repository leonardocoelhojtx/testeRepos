using Private.Domain.DTOs.Report;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepositoryReadOnly _reportRepoReadOnly;

        public ReportService(
            IReportRepositoryReadOnly reportRepoReadOnly
        )
        {
            _reportRepoReadOnly = reportRepoReadOnly;
        }

        public ReportDto GetReport(string hash, string cnpj)
        {
            var reportByHash = _reportRepoReadOnly.GetReportByHash(hash);

            if (reportByHash == null)
                return null;

            var reportDto = _reportRepoReadOnly.GetReport(hash, cnpj);

            if (reportDto == null)
                return null;

            foreach (var product in reportDto.Products)
            {
                int nullableFields = 0;

                if (product.Found == null)
                    nullableFields++;

                if (product.InconsistentTaxation == null)
                    nullableFields++;

                if (product.InconsistentNCM == null)
                    nullableFields++;

                if (product.IdealNCM == null)
                    nullableFields++;

                if (product.ICMS == null)
                    nullableFields++;

                if (product.IdealICMS == null)
                    nullableFields++;

                if (product.PIS == null)
                    nullableFields++;

                if (product.IdealPIS == null)
                    nullableFields++;

                if (product.COFINS == null)
                    nullableFields++;

                if (product.IdealCOFINS == null)
                    nullableFields++;

                if (product.IPI == null)
                    nullableFields++;

                if (product.IdealIPI == null)
                    nullableFields++;

                product.NullableFields = nullableFields;
            }

            reportDto.Products.Sort((x, y) => x.NullableFields.CompareTo(y.NullableFields));
            
            if (reportDto.Products.Count > 2)
                return RemoveExcessProducts(2, reportDto);

            return reportDto;
        }

        private ReportDto RemoveExcessProducts(int numberMax, ReportDto report)
        {
            for (int i = numberMax; i >= 0; i--)
                if (i > 1)
                    report.Products.RemoveAt(i);

            return report;
        }
    }
}