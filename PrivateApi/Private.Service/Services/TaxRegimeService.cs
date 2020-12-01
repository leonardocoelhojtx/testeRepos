using AutoMapper;
using Private.Domain.DTOs.TaxRegime;
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
    public class TaxRegimeService : ITaxRegimeService
    {
        private readonly ITaxRegimeRepositoryReadOnly _taxRegimeRepoReadOnly;
        private readonly ITaxRegimeRepository _taxRegimeRepo;
        private readonly IMapper _mapper;

        public TaxRegimeService(
            ITaxRegimeRepositoryReadOnly taxRegimeRepoReadOnly,
            ITaxRegimeRepository taxRegimeRepo,
            IMapper mapper
            ) 
        {
            _taxRegimeRepoReadOnly = taxRegimeRepoReadOnly;
            _taxRegimeRepo = taxRegimeRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaxRegimeDto>> GetAll()
        {
            var listTaxRegimeEntity = await _taxRegimeRepoReadOnly.SelectAsync();
            return _mapper.Map<List<TaxRegimeDto>>(listTaxRegimeEntity.OrderBy(x => x.Description));
        }

        public async Task<TaxRegimeDto> Get(Int64 id)
        {
            var taxRegimeEntity = await _taxRegimeRepoReadOnly.SelectAsync(id);
            return _mapper.Map<TaxRegimeDto>(taxRegimeEntity);
        }

        public async Task<TaxRegimeDto> Post(TaxRegimeDtoInsert taxRegime, Int64 idUser)
        {
            var taxRegimeModel = _mapper.Map<TaxRegimeModel>(taxRegime);
            taxRegimeModel.InclusionIdUser = idUser;
            taxRegimeModel.ChangeIdUser = idUser;

            var taxRegimeEntity = _mapper.Map<TaxRegimeEntity>(taxRegimeModel);
            var result = await _taxRegimeRepo.InsertAsync(taxRegimeEntity);

            return _mapper.Map<TaxRegimeDto>(result);
        }

        public async Task<TaxRegimeDto> Put(Int64 id, TaxRegimeDtoUpdate taxRegime, Int64 idUser)
        {
            var taxRegimeEntity = await _taxRegimeRepoReadOnly.SelectAsync(id);

            if (taxRegimeEntity == null)
                return null;

            taxRegimeEntity.Description = !String.IsNullOrEmpty(taxRegime.Description) ? taxRegime.Description : taxRegimeEntity.Description;
            taxRegimeEntity.Status = !String.IsNullOrEmpty(taxRegime.Status) ? taxRegime.Status : taxRegimeEntity.Status;
            taxRegimeEntity.ChangeIdUser = idUser;
            taxRegimeEntity.ChangeDateTime = DateTime.Now;

            var result = await _taxRegimeRepo.UpdateAsync(taxRegimeEntity);

            return _mapper.Map<TaxRegimeDto>(result);
        }
    }
}
