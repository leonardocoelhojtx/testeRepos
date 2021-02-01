using Private.Domain.DTOs.TaxRegime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface ITaxRegimeService
    {
        Task<IEnumerable<TaxRegimeDto>> GetAll();
        Task<TaxRegimeDto> Get(Int64 id);
        Task<TaxRegimeDto> Post(TaxRegimeDtoInsert taxRegime, Int64 idUser);
        Task<TaxRegimeDto> Put(Int64 id, TaxRegimeDtoUpdate taxRegime, Int64 idUser);
    }
}
