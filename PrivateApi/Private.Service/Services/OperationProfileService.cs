using AutoMapper;
using Private.Domain.DTOs.OperationProfile;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using Private.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Private.Service.Services
{
    public class OperationProfileService : IOperationProfileService
    {
        private readonly IOperationProfileRepositoryReadOnly _operationProfileRepoReadOnly;
        private readonly IOperationProfileRepository _operationProfileRepo;
        private readonly IMapper _mapper;

        public OperationProfileService(
            IOperationProfileRepositoryReadOnly operationProfileRepoReadOnly,
            IOperationProfileRepository operationProfileRepo,
            IMapper mapper
            )
        {
            _operationProfileRepoReadOnly = operationProfileRepoReadOnly;
            _operationProfileRepo = operationProfileRepo;
            _mapper = mapper;
        }

        public async Task<OperationProfileDto> Get(Int64 id)
        {
            var operationProfileEntity = await _operationProfileRepoReadOnly.SelectAsync(id);
            return _mapper.Map<OperationProfileDto>(operationProfileEntity);
        }

        public async Task<IEnumerable<OperationProfileDto>> GetAll()
        {
            var listOperationProfileEntity = await _operationProfileRepoReadOnly.SelectAsync();
            return _mapper.Map<List<OperationProfileDto>>(listOperationProfileEntity.OrderBy(x => x.Description));
        }

        public async Task<OperationProfileDto> Post(OperationProfileDtoInsert operationProfile, Int64 idUser)
        {
            var operationProfileModel = _mapper.Map<OperationProfileModel>(operationProfile);
            operationProfileModel.InclusionIdUser = idUser;
            operationProfileModel.ChangeIdUser = idUser;

            var operationProfileEntity = _mapper.Map<OperationProfileEntity>(operationProfileModel);
            var result = await _operationProfileRepo.InsertAsync(operationProfileEntity);

            return _mapper.Map<OperationProfileDto>(result);
        }

        public async Task<OperationProfileDto> Put(Int64 id, OperationProfileDtoUpdate operationProfile, Int64 idUser)
        {
            var operationProfileEntity = await _operationProfileRepoReadOnly.SelectAsync(id);

            if (operationProfileEntity == null)
                return null;

            operationProfileEntity.Description = !String.IsNullOrEmpty(operationProfile.Description) ? operationProfile.Description : operationProfileEntity.Description;
            operationProfileEntity.Status = !String.IsNullOrEmpty(operationProfile.Status) ? operationProfile.Status : operationProfileEntity.Status;
            operationProfileEntity.ChangeIdUser = idUser;
            operationProfileEntity.ChangeDateTime = DateTime.Now;

            var result = await _operationProfileRepo.UpdateAsync(operationProfileEntity);

            return _mapper.Map<OperationProfileDto>(result);
        }
    }
}
