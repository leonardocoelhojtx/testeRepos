using Microsoft.EntityFrameworkCore;
using Private.Data.Context;
using Private.Domain.DTOs.Report;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Private.Data.Repository
{
    public class ReportRepositoryReadOnly : BaseRepositoryReadOnly<ReportEntity>, IReportRepositoryReadOnly
    {
        private readonly PrivateApiReadOnlyContext _context;

        public ReportRepositoryReadOnly(PrivateApiReadOnlyContext context) : base(context)
        {
            _context = context;
        }

        public ReportDto GetReport(string hash, string cnpj)
        {
            try
            {                
                var query = (from a in _context.Reports.AsNoTracking()
                             join b in _context.RequestReports.AsNoTracking() on a.IdReportRequest equals b.Id
                             where a.Hash == hash && b.CNPJ.ToString().Substring(0, 3) == cnpj                            
                             select new ReportDto
                             {
                                 Id = a.Id,
                                 Name = b.Name,
                                 CNPJ = b.CNPJ,
                                 Phone = b.PhoneDDD + b.PhoneNumber,
                                 InclusionDateTime = a.InclusionDateTime,
                                 QuantityFound = a.QuantityFound,
                                 QuantityNotFound = a.QuantityNotFound,
                                 PercentageFound = a.PercentageFound,
                                 PercentageNotFound = a.PercentageNotFound,
                                 InconsistentAmount = a.InconsistentAmount,
                                 InconsistentAmountNCM = a.InconsistentAmountNCM,
                                 Products = (from t in _context.ItemReports where t.IdReport == a.Id
                                             select new ItemReportDto
                                             {
                                                 ReportedCode = t.ReportedCode,
                                                 InformedDescription = t.InformedDescription,
                                                 Found = t.Found,
                                                 InconsistentTaxation = t.InconsistentTaxation,
                                                 InconsistentNCM = t.InconsistentNCM,
                                                 NCM = t.NCM != null ? Convert.ToDecimal(t.NCM) : 0,
                                                 IdealNCM = t.IdealNCM != null ? Convert.ToDecimal(t.IdealNCM) : 0,
                                                 ICMS = t.ICMS != null ? t.ICMS : 0,
                                                 IdealICMS = t.IdealICMS != null ? t.IdealICMS : 0,
                                                 PIS = t.PIS != null ? t.PIS : 0,
                                                 IdealPIS = t.IdealPIS != null ? t.IdealPIS : 0,
                                                 COFINS = t.COFINS != null ? t.COFINS : 0,
                                                 IdealCOFINS = t.IdealCOFINS != null ? t.IdealCOFINS : 0,
                                                 IPI = t.IPI != null ? t.IPI : 0,
                                                 IdealIPI = t.IdealIPI != null ? t.IdealIPI : 0
                                             }).ToList()
                             }).FirstOrDefault();

                decimal countProducts = query.Products.Count();

                query.MorePisCofins = query.Products.Where(x => x.PIS > x.IdealPIS || x.COFINS > x.IdealCOFINS).Count();
                query.PercentageMorePisCofins = (query.MorePisCofins * 100) / countProducts;
                query.LessPisCofins = query.Products.Where(x => x.PIS < x.IdealPIS || x.COFINS < x.IdealCOFINS).Count();
                query.PercentageLessPisCofins = (query.LessPisCofins * 100) / countProducts;
                query.DivergentIcms = query.Products.Where(x => x.ICMS != x.IdealICMS).Count();
                query.PercentageDivergentIcms = (query.DivergentIcms * 100) / countProducts;
                query.DivergentPisCofins = query.Products.Where(x => x.PIS != x.IdealPIS || x.COFINS != x.IdealCOFINS).Count();
                query.PercentageDivergentPisCofins = (query.DivergentPisCofins * 100) / countProducts;
                query.DivergentIpi = query.Products.Where(x => x.IPI != x.IdealIPI).Count();
                query.PercentageDivergentIpi = (query.DivergentIpi * 100) / countProducts;
                query.DivergentNcm = query.Products.Where(x => x.NCM != x.IdealNCM).Count();
                query.PercentageDivergentNcm = (query.DivergentNcm * 100) / countProducts;

                return query;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public ReportEntity GetReportByHash(string hash)
        {
            return _context.Reports.AsNoTracking().Where(x => x.Hash == hash).FirstOrDefault();
        }
    }
}
