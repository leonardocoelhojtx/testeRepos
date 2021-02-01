using Private.Domain.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface IPersonService
    {
        Task<PersonDto> Get(Int64 id);
        Task<IEnumerable<PersonDto>> GetAll();
        Task<PersonDto> Post(PersonDtoCreate person);
        Task<PersonDto> Put(PersonDtoUpdate person);
        Task<bool> Delete(Int64 id);
    }
}
