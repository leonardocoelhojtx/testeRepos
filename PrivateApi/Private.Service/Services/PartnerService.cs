using AutoMapper;
using Private.Domain.DTOs.Partner;
using Private.Domain.DTOs.Person;
using Private.Domain.DTOs.PersonAddress;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using Private.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Private.Domain.DTOs.PartnetUser;
using Microsoft.EntityFrameworkCore;
using Private.Domain.DTOs.PartnerPlan;

namespace Private.Service.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepositoryReadOnly _partnerRepoReadOnly;
        private readonly IPersonRepository _personRepo;
        private readonly IPersonRepositoryReadOnly _personRepoReadOnly;
        private readonly IPartnerPersonRepositoryReadOnly _partnerPersonRepoReadOnly;
        private readonly IPartnerPersonRepository _partnerPersonRepo;
        private readonly IPartnerUserRepository _partnerUserRepo;
        private readonly IPartnerUserRepositoryReadOnly _partnerUserRepoReadOnly;
        private readonly IPartnerPlanRepositoryReadOnly _partnerPlanRepoReadOnly;
        private readonly IPartnerBillingPlanRepository _partnerBillingPlanRepository;
        private readonly IPersonAddressRepositoryReadOnly _personAddressRepoReadOnly;
        private readonly IPersonAddressRepository _personAddressRepo;
        private readonly IMapper _mapper;

        public PartnerService(
            IPartnerRepositoryReadOnly partnerRepoReadOnly,
            IPersonRepository personRepo,
            IPersonRepositoryReadOnly personRepoReadOnly,
            IPartnerPersonRepositoryReadOnly partnerPersonRepoReadOnly,
            IPartnerPersonRepository partnerPersonRepo,
            IPartnerUserRepository partnerUserRepo,
            IPartnerUserRepositoryReadOnly partnerUserRepoReadOnly,
            IPartnerPlanRepositoryReadOnly partnerPlanRepoReadOnly,
            IPartnerBillingPlanRepository partnerBillingPlanRepository,
            IPersonAddressRepositoryReadOnly personAddressRepoReadOnly,
            IPersonAddressRepository personAddressRepo,
            IMapper mapper)
        {
            _partnerRepoReadOnly = partnerRepoReadOnly;
            _personRepo = personRepo;
            _personRepoReadOnly = personRepoReadOnly;
            _partnerPersonRepoReadOnly = partnerPersonRepoReadOnly;
            _partnerPersonRepo = partnerPersonRepo;
            _partnerUserRepo = partnerUserRepo;
            _partnerUserRepoReadOnly = partnerUserRepoReadOnly;
            _partnerPlanRepoReadOnly = partnerPlanRepoReadOnly;
            _partnerBillingPlanRepository = partnerBillingPlanRepository;
            _personAddressRepoReadOnly = personAddressRepoReadOnly;
            _personAddressRepo = personAddressRepo;
            _mapper = mapper;
        }

        public async Task<PartnerDto> Get(long id)
        {
            var partnerViewEntity  = await _partnerRepoReadOnly.SelectAsync(id, true);
            var personAddressEntity = await _personAddressRepoReadOnly.SelectAddressByIdPerson(partnerViewEntity.IdPerson);
            var partnerDto = _mapper.Map<PartnerDto>(partnerViewEntity);
            partnerDto.Address = _mapper.Map<List<PersonAddressDto>>(personAddressEntity);
            return partnerDto;
        }

        public async Task<IEnumerable<PartnerResumeDto>> Get(Int64? id, string reasonName, string fantasy, Int64? cpfCnpj, string status, string filter, string filterType)
        {
            var queryPartnerViewEntity = _partnerRepoReadOnly.SelectPartners();

            if (id != null)
            {
                queryPartnerViewEntity = queryPartnerViewEntity.Where(x => x.Id == id);
            } 
            else
            {
                if (!string.IsNullOrEmpty(reasonName))
                    queryPartnerViewEntity = queryPartnerViewEntity.Where(x => x.ReasonName.ToUpper().Contains(reasonName.ToUpper()));

                if (!string.IsNullOrEmpty(fantasy))
                    queryPartnerViewEntity = queryPartnerViewEntity.Where(x => x.Fantasy.ToUpper().Contains(fantasy.ToUpper()));

                if ((cpfCnpj != null) && (cpfCnpj > 0))
                    queryPartnerViewEntity = queryPartnerViewEntity.Where(x => x.CpfCnpj == cpfCnpj);

                if (!string.IsNullOrEmpty(status) && status != "T")
                    queryPartnerViewEntity = queryPartnerViewEntity.Where(x => x.Status == status);

                if (!string.IsNullOrEmpty(filter))
                {
                    Int64 cnpj = 0;
                    try
                    {
                        cnpj = Convert.ToInt64(filter);
                    } catch (Exception ex)
                    {
                        cnpj = 0;
                    }

                    queryPartnerViewEntity =
                        string.IsNullOrEmpty(filterType) || filterType.ToUpper() == "C" ?

                            queryPartnerViewEntity.Where(x => x.ReasonName.ToUpper().Contains(filter.ToUpper()) ||
                                                              x.Fantasy.ToUpper().Contains(filter.ToUpper()) ||
                                                              x.CpfCnpj == cnpj) :

                        filterType.ToUpper() == "I" ?

                            queryPartnerViewEntity.Where(x => x.ReasonName.ToUpper().StartsWith(filter.ToUpper()) ||
                                                              x.Fantasy.ToUpper().StartsWith(filter.ToUpper()) ||
                                                              x.CpfCnpj == cnpj) :

                            queryPartnerViewEntity.Where(x => x.ReasonName.ToUpper().EndsWith(filter.ToUpper()) ||
                                                              x.Fantasy.ToUpper().EndsWith(filter.ToUpper()) ||
                                                              x.CpfCnpj == cnpj);
                }
            }

            var result = await queryPartnerViewEntity.ToListAsync();
            return _mapper.Map<List<PartnerResumeDto>>(result);
        }

        public async Task<IEnumerable<PartnerUserDto>> GetPartnerUsers(long id)
        {
            var listPartnerUserViewEntity = await _partnerUserRepoReadOnly.SelectAsync(true);
            var listPartnerUser = _mapper.Map<List<PartnerUserDto>>(listPartnerUserViewEntity);
            return listPartnerUser.Where(x => x.Id == id).OrderBy(x => x.FullName);
        }

        public async Task PutPersonAndPartner(PartnerDtoUpdate partner)
        {
            var partnerPerson = await Get(partner.Id);

            var personEntity = await _personRepoReadOnly.SelectAsync(partnerPerson.IdPerson);
            personEntity.Fantasy = partner.Fantasy;
            personEntity.Email = partner.Email;
            personEntity.PrimaryPhone = partner.PrimaryPhone;
            personEntity.AlternativePhone = partner.AlternativePhone;
            personEntity.ContactName = partner.ContactName;
            personEntity.ChangeIdUser = partner.IdUser;
            personEntity.ChangeDateTime = DateTime.Now;
            var personUpdate = await _personRepo.UpdateAsync(personEntity);

            var partnerPersonEntity = await _partnerPersonRepoReadOnly.SelectAsync(partnerPerson.Id);
            partnerPersonEntity.ChargeResponsible = partner.ChargeResponsible;
            partnerPersonEntity.ChangeIdUser = partner.IdUser;
            partnerPersonEntity.ChangeDateTime = DateTime.Now;
            await _partnerPersonRepo.UpdateAsync(partnerPersonEntity);
        }

        public async Task<PersonAddressEntity> PutPartnerAddress(Int64 idPersonAddress, Int64 idPartner, Int64 idUser, PersonAddressDtoUpdate personAddress)
        {
            var partnerPerson = await Get(idPartner);

            var listPersonAddressEntity = await _personAddressRepoReadOnly.SelectAddressByIdPerson(partnerPerson.IdPerson);
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

        public async Task PutPartnerUserSituation(Int64 idPartner, Int64 idUser, string situation)
        {
            await _partnerUserRepo.UpdatePartnerUserSituationAsync(idPartner, idUser, situation);
        }

        public async Task PostPartnerUser(Int64 idPartner, Int64 idUser, Int64 idUserLogged)
        {
            PartnerUserDtoInsert partnerUserDto = new PartnerUserDtoInsert()
            {
                IdPartner = idPartner,
                IdUser = idUser,
                Situation = "A",
                InclusionIdUser = idUserLogged,
                InclusionDateTime = DateTime.Now,
                ChangeIdUser = idUserLogged,
                ChangeDateTime = DateTime.Now
            };

            var partnerUserModel = _mapper.Map<PartnerUserModel>(partnerUserDto);
            var partnerUserEntity = _mapper.Map<PartnerUserEntity>(partnerUserModel);

            await _partnerUserRepo.InsertAsync(partnerUserEntity);
        }

        public async Task<PartnerPersonEntity> PutStatusPartnerPerson(Int64 idPartner, Int64 idUserLogged, string status)
        {
            var partnerPersonEntity = await _partnerPersonRepoReadOnly.SelectAsync(idPartner, true);
            partnerPersonEntity.Status = !string.IsNullOrEmpty(status) ? status : partnerPersonEntity.Status;
            partnerPersonEntity.ChangeIdUser = idUserLogged;
            partnerPersonEntity.ChangeDateTime = DateTime.Now;

            return await _partnerPersonRepo.UpdateAsync(partnerPersonEntity);
        }

        public async Task PutStatusPartnerBillingPlan(Int64 idPartnerBillingPlan, Int64 idUserLogged, string status)
        {
            var partnerBillinPlanEntity = await _partnerBillingPlanRepository.SelectAsync(idPartnerBillingPlan, true);
            partnerBillinPlanEntity.Situation = !string.IsNullOrEmpty(status) ? status : partnerBillinPlanEntity.Situation;
            partnerBillinPlanEntity.ChangeIdUser = idUserLogged;
            partnerBillinPlanEntity.ChangeDateTime = DateTime.Now;

            await _partnerBillingPlanRepository.UpdateAsync(partnerBillinPlanEntity);
        }

        public async Task<PartnerPlanDto> PostPartnerBillingPlan(PartnerBillingPlanDtoInsert partnerBillingPlanDtoInsert, Int64 idUserLogged)
        {
            var ListPartnerBillingPlanEntity = await _partnerBillingPlanRepository.SelectPlanByDateOfTerm(
                partnerBillingPlanDtoInsert.IdPartnerPerson, partnerBillingPlanDtoInsert.IdBillingPlan,
                partnerBillingPlanDtoInsert.StartOfTerm, partnerBillingPlanDtoInsert.EndOfTerm);

            if (ListPartnerBillingPlanEntity.Count() > 0)
                return null;

            var partnerBillingPlanModel = _mapper.Map<PartnerBillingPlanModel>(partnerBillingPlanDtoInsert);
            partnerBillingPlanModel.Situation = partnerBillingPlanDtoInsert.Situation == null ? "A" : partnerBillingPlanDtoInsert.Situation;
            partnerBillingPlanModel.Visibility = partnerBillingPlanDtoInsert.Visibility == null ? "T" : partnerBillingPlanDtoInsert.Visibility;
            partnerBillingPlanModel.InclusionIdUser = idUserLogged;
            partnerBillingPlanModel.ChangeIdUser = idUserLogged;
            var partnerBillingPlanEntity = _mapper.Map<PartnerBillingPlanEntity>(partnerBillingPlanModel);

            var result = await _partnerBillingPlanRepository.InsertAsync(partnerBillingPlanEntity);

            var query = await _partnerPlanRepoReadOnly.GetPartnerPlanById(result.Id);

            var resultQuery = query
                .GroupBy(s => new {
                    s.Id,
                    s.IdPartnerPerson,
                    s.ReasonName,
                    s.Fantasy,
                    s.ChargeResponsible,
                    s.AccessCode,
                    s.StartOfTerm,
                    s.EndOfTerm,
                    s.IdBillingPlan,
                    s.BillingPlanCode,
                    s.BillingPlanDescription,
                    s.EffectiveDays,
                    s.GraceDays,
                    s.BillingCycle,
                    s.SaleValue,
                    s.PartnerValue,
                    s.ResaleValue,
                    s.Visibility,
                    s.Situation
                }, (group, list) => new { group, list })
                .Select(x => new PartnerPlanDto()
                {
                    Id = x.group.Id,
                    IdPartnerPerson = x.group.IdPartnerPerson,
                    ReasonName = x.group.ReasonName,
                    Fantasy = x.group.Fantasy,
                    ChargeResponsible = x.group.ChargeResponsible,
                    AccessCode = x.group.AccessCode,
                    StartOfTerm = x.group.StartOfTerm,
                    EndOfTerm = x.group.EndOfTerm,
                    IdBillingPlan = x.group.IdBillingPlan,
                    BillingPlanCode = x.group.BillingPlanCode,
                    BillingPlanDescription = x.group.BillingPlanDescription,
                    EffectiveDays = x.group.EffectiveDays,
                    GraceDays = x.group.GraceDays,
                    BillingCycle = x.group.BillingCycle,
                    SaleValue = x.group.SaleValue,
                    PartnerValue = x.group.PartnerValue,
                    ResaleValue = x.group.ResaleValue,
                    Visibility = x.group.Visibility,
                    Situation = x.group.Situation,
                    Attributes = x.list.Select(y => new PartnerPlanAttributesDto()
                    {
                        Feature = y.Feature,
                        Quantity = y.Quantity,
                        Unlimited = y.Unlimited,
                        IdPlanAttribute = y.IdPlanAttribute
                    }).ToList()
                }).FirstOrDefault();

            return resultQuery;
        }

        public async Task<PartnerDto> PostPartner(Int64 idUserLogged, PartnerDtoInsert partner)
        {
            PersonDtoCreate person = new PersonDtoCreate()
            {
                ReasonName = partner.ReasonName,
                Fantasy = partner.Fantasy,
                CpfCnpj = partner.CpfCnpj,
                BirthDateTime = partner.BirthDateTime,
                Email = partner.Email,
                PrimaryPhone = partner.PrimaryPhone,
                AlternativePhone = partner.AlternativePhone,
                LegalPhysics = partner.LegalPhysics,
                ContactName = partner.ContactName,
            };

            var personModel = _mapper.Map<PersonModel>(person);
            personModel.InclusionIdUser = idUserLogged;
            personModel.ChangeIdUser = idUserLogged;

            var personEntity = _mapper.Map<PersonEntity>(personModel);
            await _personRepo.InsertAsync(personEntity);

            PersonAddressDtoInsert personAddress = new PersonAddressDtoInsert()
            {
                Cep = partner.Cep,
                Street = partner.Street,
                Number = partner.Number,
                Complement = partner.Complement,
                Neighborhood = partner.Neighborhood,
                City = partner.City,
                State = partner.State,
                Country = partner.Country
            };

            var personAddressModel = _mapper.Map<PersonAddressModel>(personAddress);
            personAddressModel.IdPerson = personEntity.Id;
            personAddressModel.Type = 1;
            personAddressModel.InclusionIdUser = idUserLogged;
            personAddressModel.ChangeIdUser = idUserLogged;

            var personAddressEntity = _mapper.Map<PersonAddressEntity>(personAddressModel);
            await _personAddressRepo.InsertAsync(personAddressEntity);

            PartnerPersonDtoInsert partnerPerson = new PartnerPersonDtoInsert()
            {
                Status = "A",
                ChargeResponsible = partner.ChargeResponsible
            };

            var partnerPersonModel = _mapper.Map<PartnerPersonModel>(partnerPerson);
            partnerPersonModel.IdPerson = personEntity.Id;
            partnerPersonModel.InclusionIdUser = idUserLogged;
            partnerPersonModel.ChangeIdUser = idUserLogged;

            var partnerPersonEntity = _mapper.Map<PartnerPersonEntity>(partnerPersonModel);
            await _partnerPersonRepo.InsertAsync(partnerPersonEntity);

            return await Get(partnerPersonEntity.Id);
        }

        public async Task<IEnumerable<PartnerPlanDto>> GetPartnerPlan(Int64 idPartner)
        {
            var query = await _partnerPlanRepoReadOnly.GetPartnerPlan(idPartner);

            var result = query
                .GroupBy(s => new { s.Id, s.IdPartnerPerson, s.ReasonName, s.Fantasy, s.ChargeResponsible, s.AccessCode, s.StartOfTerm, s.EndOfTerm, 
                                    s.IdBillingPlan, s.BillingPlanCode, s.BillingPlanDescription, s.EffectiveDays, s.GraceDays, s.BillingCycle, 
                                    s.SaleValue, s.PartnerValue, s.ResaleValue, s.Visibility, s.Situation}, (group, list) => new { group, list })
                .Select(x => new PartnerPlanDto()
                {
                    Id = x.group.Id,
                    IdPartnerPerson = x.group.IdPartnerPerson,
                    ReasonName = x.group.ReasonName,
                    Fantasy = x.group.Fantasy,
                    ChargeResponsible = x.group.ChargeResponsible,
                    AccessCode = x.group.AccessCode,
                    StartOfTerm = x.group.StartOfTerm,
                    EndOfTerm = x.group.EndOfTerm,
                    IdBillingPlan = x.group.IdBillingPlan,
                    BillingPlanCode = x.group.BillingPlanCode,
                    BillingPlanDescription = x.group.BillingPlanDescription,
                    EffectiveDays = x.group.EffectiveDays,
                    GraceDays = x.group.GraceDays,
                    BillingCycle = x.group.BillingCycle,
                    SaleValue = x.group.SaleValue,
                    PartnerValue = x.group.PartnerValue,
                    ResaleValue = x.group.ResaleValue,
                    Visibility = x.group.Visibility,
                    Situation = x.group.Situation,
                    Attributes = x.list.Select(y => new PartnerPlanAttributesDto()
                    {
                        Feature = y.Feature,
                        Quantity = y.Quantity,
                        Unlimited = y.Unlimited,
                        IdPlanAttribute = y.IdPlanAttribute
                    }).ToList()
                });

            return result;
        }
    }
}
