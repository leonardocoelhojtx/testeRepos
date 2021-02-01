using AutoMapper;
using Private.Domain.DTOs.TaxScenario;
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
    public class TaxScenarioService : ITaxScenarioService
    {
        private readonly ITaxScenarioRepositoryReadOnly _taxScenarioRepoReadOnly;
        private readonly ITaxScenarioRepository _taxScenarioRepo;
        private readonly IMapper _mapper;

        public TaxScenarioService(
            ITaxScenarioRepositoryReadOnly taxScenarioRepoReadOnly,
            ITaxScenarioRepository taxScenarioRepo,
            IMapper mapper
            )
        {
            _taxScenarioRepoReadOnly = taxScenarioRepoReadOnly;
            _taxScenarioRepo = taxScenarioRepo;
            _mapper = mapper;
        }

        public async Task<TaxScenarioDto> Get(long id)
        {
            var taxScenarioViewEntity = await _taxScenarioRepoReadOnly.SelectAsync(id);
            return _mapper.Map<TaxScenarioDto>(taxScenarioViewEntity);
        }

        public async Task<IEnumerable<TaxScenarioDto>> GetAll()
        {
            var listTaxScenarioViewEntity = await _taxScenarioRepoReadOnly.SelectAsync();
            return _mapper.Map<List<TaxScenarioDto>>(listTaxScenarioViewEntity.OrderBy(x => x.Description));
        }

        public async Task<TaxScenarioDto> Post(TaxScenarioDtoInsert taxScenario, long idUser)
        {
            var taxScenarioModel = _mapper.Map<TaxScenarioModel>(taxScenario);
            taxScenarioModel.InclusionIdUser = idUser;
            taxScenarioModel.ChangeIdUser = idUser;

            var taxScenarioEntity = _mapper.Map<TaxScenarioEntity>(taxScenarioModel);
            var result = await _taxScenarioRepo.InsertAsync(taxScenarioEntity);

            var taxScenarioViewEntity = await _taxScenarioRepoReadOnly.SelectAsync(result.Id);
            return _mapper.Map<TaxScenarioDto>(taxScenarioViewEntity);
        }

        public async Task<TaxScenarioDto> Put(long id, TaxScenarioDtoUpdate taxScenario, long idUser)
        {
            var taxScenarioEntity = await _taxScenarioRepo.SelectAsync(id);

            if (taxScenarioEntity == null)
                return null;

            taxScenarioEntity.Description = !String.IsNullOrEmpty(taxScenario.Description) ? taxScenario.Description : taxScenarioEntity.Description;
            taxScenarioEntity.IdRegime = taxScenario.IdRegime > 0 ? taxScenario.IdRegime : taxScenarioEntity.IdRegime;
            taxScenarioEntity.IdOriginProfile = taxScenario.IdOriginProfile;
            taxScenarioEntity.IdDestinationProfile = taxScenario.IdDestinationProfile;
            taxScenarioEntity.OriginUF = taxScenario.OriginUF;
            taxScenarioEntity.DestinationUF = taxScenario.DestinationUF;
            taxScenarioEntity.CNAE = taxScenario.CNAE;
            taxScenarioEntity.StartOfTerm = taxScenario.StartOfTerm != null ? taxScenario.StartOfTerm : taxScenarioEntity.StartOfTerm;
            taxScenarioEntity.EndOfTerm = taxScenario.EndOfTerm;
            taxScenarioEntity.IdOperationNature = taxScenario.IdOperationNature;
            taxScenarioEntity.Status = !String.IsNullOrEmpty(taxScenario.Status) ? taxScenario.Status : taxScenarioEntity.Status;
            taxScenarioEntity.ChangeIdUser = idUser;
            taxScenarioEntity.ChangeDateTime = DateTime.Now;

            var result = await _taxScenarioRepo.UpdateAsync(taxScenarioEntity);

            var taxScenarioViewEntity = await _taxScenarioRepoReadOnly.SelectAsync(result.Id);
            return _mapper.Map<TaxScenarioDto>(taxScenarioViewEntity);
        }
    }
}
