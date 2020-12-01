using AutoMapper;
using Private.Domain.DTOs.Customer;
using Private.Domain.DTOs.OperationNature;
using Private.Domain.DTOs.OperationProfile;
using Private.Domain.DTOs.Partner;
using Private.Domain.DTOs.Person;
using Private.Domain.DTOs.PersonAddress;
using Private.Domain.DTOs.Product;
using Private.Domain.DTOs.QueryLog;
using Private.Domain.DTOs.SalesPlan;
using Private.Domain.DTOs.TaxRegime;
using Private.Domain.DTOs.TaxScenario;
using Private.Domain.DTOs.User;
using Private.Domain.Entities;
using System.Collections.Generic;

namespace Private.Crosscuting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<PersonDto, PersonEntity> ()
                .ReverseMap();
            CreateMap<CustomerDto, CustomerViewEntity>()
                .ReverseMap();
            CreateMap<CustomerUserDto, CustomerUserViewEntity>()
                .ReverseMap();
            CreateMap<PartnerDto, PartnerViewEntity>()
                .ReverseMap();
            CreateMap<PartnerUserDto, PartnerUserViewEntity>()
                .ReverseMap();
            CreateMap<PersonAddressDto, PersonAddressEntity>()
                .ReverseMap();
            CreateMap<UserDto, UserViewEntity>()
                .ReverseMap();
            CreateMap<TaxRegimeDto, TaxRegimeEntity>()
                .ReverseMap();
            CreateMap<OperationNatureDto, OperationNatureEntity>()
                .ReverseMap();
            CreateMap<OperationProfileDto, OperationProfileEntity>()
                .ReverseMap();
            CreateMap<ProductDto, ProductEntity>()
                .ReverseMap();
            CreateMap<TaxScenarioDto, TaxScenarioViewEntity>()
                .ReverseMap();
            CreateMap<QueryLogDto, QueryLogViewEntity>()
                .ReverseMap();
            CreateMap<BillingAttributeDto, BillingAttributeEntity>()
                .ReverseMap();
            CreateMap<BillingPlanDto, BillingPlanEntity>()
                .ReverseMap();
            CreateMap<PlanAttributeDto, PlanAttributeEntity>()
                .ReverseMap();
            CreateMap<PartnerResumeDto, PartnerViewEntity>()
                .ReverseMap();
        }
        
    }
}