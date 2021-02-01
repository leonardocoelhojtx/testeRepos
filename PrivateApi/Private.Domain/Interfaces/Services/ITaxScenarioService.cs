using Private.Domain.DTOs.TaxScenario;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface ITaxScenarioService
    {
        Task<IEnumerable<TaxScenarioDto>> GetAll();
        Task<TaxScenarioDto> Get(Int64 id);
        Task<TaxScenarioDto> Post(TaxScenarioDtoInsert taxScenario, Int64 idUser);
        Task<TaxScenarioDto> Put(Int64 id, TaxScenarioDtoUpdate taxScenario, Int64 idUser);
    }
}
