using Private.Domain.DTOs.OperationNature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface IOperationNatureService
    {
        Task<IEnumerable<OperationNatureDto>> GetAll();
        Task<OperationNatureDto> Get(Int64 id);
        Task<OperationNatureDto> Post(OperationNatureDtoInsert operationNature, Int64 idUser);
        Task<OperationNatureDto> Put(Int64 id, OperationNatureDtoUpdate operationNature, Int64 idUser);
    }
}
