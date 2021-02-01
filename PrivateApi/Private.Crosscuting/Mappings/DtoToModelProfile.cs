using AutoMapper;
using Private.Domain.DTOs.Customer;
using Private.Domain.DTOs.CustomerUser;
using Private.Domain.DTOs.OperationNature;
using Private.Domain.DTOs.OperationProfile;
using Private.Domain.DTOs.Partner;
using Private.Domain.DTOs.PartnerPlan;
using Private.Domain.DTOs.PartnetUser;
using Private.Domain.DTOs.Person;
using Private.Domain.DTOs.PersonAddress;
using Private.Domain.DTOs.Product;
using Private.Domain.DTOs.SalesPlan;
using Private.Domain.DTOs.TaxRegime;
using Private.Domain.DTOs.TaxScenario;
using Private.Domain.Models;

namespace Private.Crosscuting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<CustomerModel, CustomerDto>()
                .ReverseMap();
            CreateMap<CustomerModel, CustomerDtoCreateRequest>()
                .ReverseMap();
            CreateMap<CustomerModel, CustomerDtoUpdate>()
                .ReverseMap();
            CreateMap<CustomerUserModel, CustomerUserDtoInsert>()
                .ReverseMap();
            CreateMap<PartnerModel, PartnerDto>()
                 .ReverseMap();
            CreateMap<PartnerModel, PartnerDtoUpdate>()
                .ReverseMap();
            CreateMap<PartnerUserModel, PartnerUserDtoInsert>()
                .ReverseMap();
            CreateMap<PersonModel, PersonDtoUpdate>()
                .ReverseMap();
            CreateMap<TaxRegimeModel, TaxRegimeDtoInsert>()
                .ReverseMap();
            CreateMap<OperationNatureModel, OperationNatureDtoInsert>()
                .ReverseMap();
            CreateMap<OperationProfileModel, OperationProfileDtoInsert>()
                .ReverseMap();
            CreateMap<ProductModel, ProductDtoInsert>()
                .ReverseMap();
            CreateMap<TaxScenarioModel, TaxScenarioDtoInsert>()
                .ReverseMap();
            CreateMap<BillingAttributeModel, BillingAttributeDtoInsert>()
                .ReverseMap();
            CreateMap<BillingPlanModel, BillingPlanDtoInsert>()
                .ReverseMap();
            CreateMap<PlanAttributeModel, PlanAttributeDtoInsert>()
                .ReverseMap();
            CreateMap<PersonModel, PersonDtoCreate>()
                .ReverseMap();
            CreateMap<PersonAddressModel, PersonAddressDtoInsert>()
                .ReverseMap();
            CreateMap<PartnerPersonModel, PartnerPersonDtoInsert>()
                .ReverseMap();
            CreateMap<PartnerBillingPlanModel, PartnerBillingPlanDtoInsert>()
                 .ReverseMap();
        }
    }
}