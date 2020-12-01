using Private.Domain.DTOs.OperationProfile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface IOperationProfileService
    {
        Task<IEnumerable<OperationProfileDto>> GetAll();
        Task<OperationProfileDto> Get(Int64 id);
        Task<OperationProfileDto> Post(OperationProfileDtoInsert operationProfile, Int64 idUser);
        Task<OperationProfileDto> Put(Int64 id, OperationProfileDtoUpdate operationProfile, Int64 idUser);
    }
}
