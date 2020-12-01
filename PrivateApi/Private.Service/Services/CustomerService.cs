using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Private.Domain.DTOs.Customer;
using Private.Domain.DTOs.Person;
using Private.Domain.DTOs.PersonAddress;
using Private.Domain.Entities;
using Private.Domain.Interfaces;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using Private.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Private.Domain.DTOs.CustomerUser;

namespace Private.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepositoryReadOnly _customerRepoReadOnly;
        private readonly IPersonRepository _personRepo;
        private readonly IPersonRepositoryReadOnly _personRepoReadOnly;
        private readonly ICustomerPersonRepositoryReadOnly _customerPersonRepoReadOnly;
        private readonly ICustomerPersonRepository _customerPersonRepo;
        private readonly ICustomerUserRepository _customerUserRepo;
        private readonly ICustomerUserRepositoryReadOnly _customerUserRepoReadOnly;
        private readonly IPersonAddressRepositoryReadOnly _personAddressRepoReadOnly;
        private readonly IPersonAddressRepository _personAddressRepo;
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerRepositoryReadOnly customerRepoReadOnly,
            ICustomerPersonRepositoryReadOnly customerPersonRepoReadOnly,
            ICustomerPersonRepository customerPersonRepo,
            ICustomerUserRepository customerUserRepo,
            ICustomerUserRepositoryReadOnly customerUserRepoReadOnly,
            IPersonRepository personRepo,
            IPersonRepositoryReadOnly personRepoReadOnly,
            IPersonAddressRepositoryReadOnly personAddressRepoReadOnly,
            IPersonAddressRepository personAddressRepo,
        IMapper mapper)
        {
            _customerRepoReadOnly = customerRepoReadOnly;
            _personRepo = personRepo;
            _personRepoReadOnly = personRepoReadOnly;
            _customerPersonRepo = customerPersonRepo;
            _customerPersonRepoReadOnly = customerPersonRepoReadOnly;
            _customerUserRepo = customerUserRepo;
            _customerUserRepoReadOnly = customerUserRepoReadOnly;
            _personAddressRepoReadOnly = personAddressRepoReadOnly;
            _personAddressRepo = personAddressRepo;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Get(Int64 id)
        {
            var customerEntity = await _customerRepoReadOnly.SelectAsync(id, true);
            var personAddressEntity = await _personAddressRepoReadOnly.SelectAddressByIdPerson(customerEntity.IdPerson);
            var customerDto = _mapper.Map<CustomerDto>(customerEntity);
            customerDto.Address = _mapper.Map<List<PersonAddressDto>>(personAddressEntity);
            return customerDto;
        }

        public async Task<IEnumerable<CustomerUserDto>> GetCustomerUsers(long id)
        {
            var listPartnerUserViewEntity = await _customerUserRepoReadOnly.SelectAsync(false);
            var listPartnerUser = _mapper.Map<List<CustomerUserDto>>(listPartnerUserViewEntity);
            return listPartnerUser.Where(x => x.Id == id).OrderBy(x => x.FullName);
        }

        //public async Task<CustomerDto> Post(CustomerDtoCreateRequest customer)
        //{
        //    var personModel = new PersonModel()
        //    {
        //        CpfCnpj = customer.CpfCnpj,
        //        NomeRazao = customer.RazaoSocial,
        //        Fantasy = customer.NomeFantasia,
        //        DtaNascimento = customer.DataNascFundacao,
        //        Email = customer.Email,
        //        TelefoneDdd = customer.TelefonePrincipal.Substring(0,2),
        //        TelefoneNro = customer.TelefonePrincipal.Substring(2),
        //        EnderecoCep = customer.Endereco.Cep,
        //        EnderecoBairro = customer.Endereco.Bairro,
        //        EnderecoLogradouro = customer.Endereco.Logradouro,
        //        EnderecoLogradouroNro = customer.Endereco.Numero,
        //        EnderecoCidade = customer.Endereco.Cidade,
        //        EnderecoEstado = customer.Endereco.Estado,
        //        EnderecoPais = "Brasil"
        //    };

        //    var personEntity = _mapper.Map<PersonEntity>(personModel);
        //    var personResult = await _personRepo.InsertAsync(personEntity);

        //    var customerModel = _mapper.Map<CustomerModel>(customer);
        //    var customerEntity = _mapper.Map<CustomerEntity>(customerModel);

        //    customerEntity.Person = personResult;
        //    customerEntity.IdPessoa = personResult.Id;

        //    var customerResult = await _customerRepo.InsertAsync(customerEntity);

        //    return _mapper.Map<CustomerDto>(customerResult);
        //}

        //public async Task<CustomerDto> Put(CustomerDtoUpdate customer)
        //{
        //    var model = _mapper.Map<CustomerModel>(customer);
        //    var entity = _mapper.Map<CustomerEntity>(model);
        //    var result = await _customerRepo.UpdateAsync(entity);
        //    return _mapper.Map<CustomerDto>(result);
        //}

        public async Task PutPersonAndCustomer(CustomerDtoUpdate customer)
        {
            var customerPerson = await Get(customer.Id);

            var personEntity = await _personRepoReadOnly.SelectAsync(customerPerson.IdPerson);
            personEntity.Fantasy = customer.Fantasy;
            personEntity.Email = customer.Email;
            personEntity.PrimaryPhone = customer.PrimaryPhone;
            personEntity.AlternativePhone = customer.AlternativePhone;
            personEntity.ChangeIdUser = customer.IdUser;
            personEntity.ChangeDateTime = DateTime.Now;
            var personUpdate = await _personRepo.UpdateAsync(personEntity);

            var customerPersonEntity = await _customerPersonRepoReadOnly.SelectAsync(customerPerson.Id);
            customerPersonEntity.ChangeIdUser = customer.IdUser;
            customerPersonEntity.ChangeDateTime = DateTime.Now;
            await _customerPersonRepo.UpdateAsync(customerPersonEntity);

            //PersonDtoUpdate person = new PersonDtoUpdate()
            //{
            //    Id = customerPerson.IdPerson,
            //    Fantasy = customer.Fantasy,
            //    Email = customer.Email,
            //    PrimaryPhone = customer.PrimaryPhone,
            //    AlternativePhone = customer.AlternativePhone
            //};

            ////Altera os dados da pessoa
            //var personModel = _mapper.Map<PersonModel>(person);
            //var personEntity = _mapper.Map<PersonEntity>(personModel);
            //personEntity.ChangeIdUser = customer.IdUser;
            //personEntity.ChangeDateTime = DateTime.Now;
            //var personUpdate = await _personRepo.UpdateAsync(personEntity);

            ////Altera os dados do cliente
            //CustomerPersonEntity customerPersonEntity = new CustomerPersonEntity();
            //customerPersonEntity.Id = customer.Id;
            //customerPersonEntity.ChangeIdUser = customer.IdUser;
            //customerPersonEntity.ChangeDateTime = DateTime.Now;

            //return await _customerPersonRepo.UpdateAsync(customerPersonEntity);
        }

        public async Task<PersonAddressEntity> PutPartnerAddress(Int64 idPersonAddress, Int64 idCustomer, Int64 idUser, PersonAddressDtoUpdate personAddress)
        {
            var customerPerson = await Get(idCustomer);

            var listPersonAddressEntity = await _personAddressRepoReadOnly.SelectAddressByIdPerson(customerPerson.IdPerson);
            var address = listPersonAddressEntity.FirstOrDefault(x => x.Id == idPersonAddress && x.type == 1);

            address.cep = personAddress.Cep;
            address.street = personAddress.Street;
            address.number = personAddress.Number;
            address.complement = personAddress.Complement;
            address.neighborhood = personAddress.Neighborhood;
            address.city = personAddress.City;
            address.state = personAddress.State != null ? personAddress.State.ToUpper() : null;
            address.changeIdUser = idUser;
            address.changeDateTime = DateTime.Now;

            return await _personAddressRepo.UpdateAsync(address);
        }

        public async Task PutCustomerUserSituation(Int64 idCustomer, Int64 idUser, string situation)
        {
            await _customerUserRepo.UpdateCustomerUserSituationAsync(idCustomer, idUser, situation);
        }

        public async Task PostCustomerUser(Int64 idCustomer, Int64 idUser, Int64 idUserLogged)
        {
            CustomerUserDtoInsert customerUserDto = new CustomerUserDtoInsert()
            {
                IdCustomer = idCustomer,
                IdUser = idUser,
                Situation = "A",
                InclusionIdUser = idUserLogged,
                InclusionDateTime = DateTime.Now,
                ChangeIdUser = idUserLogged,
                ChangeDateTime = DateTime.Now
            };

            var customerUserModel = _mapper.Map<CustomerUserModel>(customerUserDto);
            var customerUserEntity = _mapper.Map<CustomerUserEntity>(customerUserModel);

            await _customerUserRepo.InsertAsync(customerUserEntity);
        }
    }
}
