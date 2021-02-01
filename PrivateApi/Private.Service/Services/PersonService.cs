using AutoMapper;
using Private.Domain.DTOs.Person;
using Private.Domain.Entities;
using Private.Domain.Interfaces;
using Private.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<PersonEntity> _repository;
        private readonly IMapper _mapper;

        public PersonService(IRepository<PersonEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Int64 id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PersonDto> Get(Int64 id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<PersonDto>(entity);
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<PersonDto>>(listEntity);
        }

        public async Task<PersonDto> Post(PersonDtoCreate person)
        {
            var entity = _mapper.Map<PersonEntity>(person);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<PersonDto>(result);
        }

        public async Task<PersonDto> Put(PersonDtoUpdate person)
        {
            var entity = _mapper.Map<PersonEntity>(person);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<PersonDto>(result);
        }
    }
}
