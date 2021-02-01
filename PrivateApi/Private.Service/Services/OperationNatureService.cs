using AutoMapper;
using Private.Domain.DTOs.OperationNature;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Private.Domain.Models;
using Private.Domain.Entities;
using System.Linq;

namespace Private.Service.Services
{
    public class OperationNatureService : IOperationNatureService
    {
        private readonly IOperationNatureRepositoryReadOnly _operationNatureRepoReadOnly;
        private readonly IOperationNatureRepository _operationNatureRepo;
        private readonly IMapper _mapper;

        public OperationNatureService(
            IOperationNatureRepositoryReadOnly operationNatureRepoReadOnly,
            IOperationNatureRepository operationNatureRepo,
            IMapper mapper
            )
        {
            _operationNatureRepoReadOnly = operationNatureRepoReadOnly;
            _operationNatureRepo = operationNatureRepo;
            _mapper = mapper;
        }

        public async Task<OperationNatureDto> Get(Int64 id)
        {
            var operationNatureEntity = await _operationNatureRepoReadOnly.SelectAsync(id);
            return _mapper.Map<OperationNatureDto>(operationNatureEntity);
        }

        public async Task<IEnumerable<OperationNatureDto>> GetAll()
        {
            var listOperationNatureEntity = await _operationNatureRepoReadOnly.SelectAsync();
            return _mapper.Map<List<OperationNatureDto>>(listOperationNatureEntity.OrderBy(x => x.Description));
        }

        public async Task<OperationNatureDto> Post(OperationNatureDtoInsert operationNature, Int64 idUser)
        {
            var operationNatureModel = _mapper.Map<OperationNatureModel>(operationNature);
            operationNatureModel.InclusionIdUser = idUser;
            operationNatureModel.ChangeIdUser = idUser;

            var operationNatureEntity = _mapper.Map<OperationNatureEntity>(operationNatureModel);
            var result = await _operationNatureRepo.InsertAsync(operationNatureEntity);

            return _mapper.Map<OperationNatureDto>(result);
        }

        public async Task<OperationNatureDto> Put(Int64 id, OperationNatureDtoUpdate operationNature, Int64 idUser)
        {
            var operationNatureEntity = await _operationNatureRepoReadOnly.SelectAsync(id);

            if (operationNatureEntity == null)
                return null;

            operationNatureEntity.Description = !String.IsNullOrEmpty(operationNature.Description) ? operationNature.Description : operationNatureEntity.Description;
            operationNatureEntity.Status = !String.IsNullOrEmpty(operationNature.Status) ? operationNature.Status : operationNatureEntity.Status;
            operationNatureEntity.ChangeIdUser = idUser;
            operationNatureEntity.ChangeDateTime = DateTime.Now;

            var result = await _operationNatureRepo.UpdateAsync(operationNatureEntity);

            return _mapper.Map<OperationNatureDto>(result);
        }
    }
}
