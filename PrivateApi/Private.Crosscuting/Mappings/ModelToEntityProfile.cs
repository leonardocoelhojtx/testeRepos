using AutoMapper;
using Private.Domain.Entities;
using Private.Domain.Models;

namespace Private.Crosscuting.Mappings
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<PersonEntity, PersonModel>()
                .ReverseMap();
            CreateMap<PartnerViewEntity, PartnerModel>()
                .ReverseMap();
            CreateMap<PartnerUserEntity, PartnerUserModel>()
                .ReverseMap();
            CreateMap<PersonEntity, PersonModel>()
                .ReverseMap();
            CreateMap<CustomerUserEntity, CustomerUserModel>()
                .ReverseMap();
            CreateMap<TaxRegimeEntity, TaxRegimeModel>()
                .ReverseMap();
            CreateMap<OperationNatureEntity, OperationNatureModel>()
                .ReverseMap();
            CreateMap<OperationProfileEntity, OperationProfileModel>()
                .ReverseMap();
            CreateMap<ProductEntity, ProductModel>()
                .ReverseMap();
            CreateMap<TaxScenarioEntity, TaxScenarioModel>()
                .ReverseMap();
            CreateMap<BillingAttributeEntity, BillingAttributeModel>()
                .ReverseMap();
            CreateMap<BillingPlanEntity, BillingPlanModel>()
                .ReverseMap();
            CreateMap<PlanAttributeEntity, PlanAttributeModel>()
                .ReverseMap();
            CreateMap<PersonAddressEntity, PersonAddressModel>()
                .ReverseMap();
            CreateMap<PartnerPersonEntity, PartnerPersonModel>()
                .ReverseMap();
            CreateMap<PartnerBillingPlanEntity, PartnerBillingPlanModel>()
                .ReverseMap();
        }        
    }
}