using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Private.Data.Context;
using Private.Data.Repository;
using Private.Domain.Interfaces;
using Private.Domain.Interfaces.Repositories;

namespace Private.Crosscuting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository (IServiceCollection serviceCollection, string connectionString, string connectionStringReadOnly)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IRepositoryReadOnly<>), typeof(BaseRepositoryReadOnly<>));

            serviceCollection.AddDbContext<PrivateApiContext>
            (
                options => {
                    options.UseMySql(connectionString);
                }
            );

            serviceCollection.AddDbContext<PrivateApiReadOnlyContext>
            (
                options => {
                    options.UseMySql(connectionStringReadOnly);
                }
            );

            serviceCollection.AddScoped<IPartnerRepository, PartnerRepository>();
            serviceCollection.AddScoped<IPartnerRepositoryReadOnly, PartnerRepositoryReadOnly>();
            serviceCollection.AddScoped<IPartnerPersonRepository, PartnerPersonRepository>();
            serviceCollection.AddScoped<IPartnerPersonRepositoryReadOnly, PartnerPersonRepositoryReadOnly>();
            serviceCollection.AddScoped<IPartnerUserRepository, PartnerUserRepository>();
            serviceCollection.AddScoped<IPartnerUserRepositoryReadOnly, PartnerUserRepositoryReadOnly>();
            serviceCollection.AddScoped<IPartnerPlanRepositoryReadOnly, PartnerPlanRepositoryReadOnly>();
            serviceCollection.AddScoped<IPartnerBillingPlanRepository, PartnerBillingPlanRepository>();

            serviceCollection.AddScoped<ICustomerRepositoryReadOnly, CustomerRepositoryReadOnly>();
            serviceCollection.AddScoped<ICustomerPersonRepository, CustomerPersonRepository>();
            serviceCollection.AddScoped<ICustomerPersonRepositoryReadOnly, CustomerPersonRepositoryReadOnly>();
            serviceCollection.AddScoped<ICustomerUserRepository, CustomerUserRepository>();
            serviceCollection.AddScoped<ICustomerUserRepositoryReadOnly, CustomerUserRepositoryReadOnly>();

            serviceCollection.AddScoped<IPersonRepositoryReadOnly, PersonRepositoryReadOnly>();
            serviceCollection.AddScoped<IPersonRepository, PersonRepository>();
            serviceCollection.AddScoped<IPersonAddressRepositoryReadOnly, PersonAddressRepositoryReadOnly>();
            serviceCollection.AddScoped<IPersonAddressRepository, PersonAddressRepository>();

            serviceCollection.AddScoped<IUserRepositoryReadOnly, UserRepositoryReadOnly>();

            serviceCollection.AddScoped<ITaxRegimeRepositoryReadOnly, TaxRegimeRepositoryReadOnly>();
            serviceCollection.AddScoped<ITaxRegimeRepository, TaxRegimeRepository>();

            serviceCollection.AddScoped<IOperationNatureRepositoryReadOnly, OperationNatureRepositoryReadOnly>();
            serviceCollection.AddScoped<IOperationNatureRepository, OperationNatureRepository>();

            serviceCollection.AddScoped<IOperationProfileRepositoryReadOnly, OperationProfileRepositoryReadOnly>();
            serviceCollection.AddScoped<IOperationProfileRepository, OperationProfileRepository>();

            serviceCollection.AddScoped<IProductRepositoryReadOnly, ProductRepositoryReadOnly>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();

            serviceCollection.AddScoped<ITaxScenarioRepositoryReadOnly, TaxScenarioRepositoryReadOnly>();
            serviceCollection.AddScoped<ITaxScenarioRepository, TaxScenarioRepository>();

            serviceCollection.AddScoped<IQueryLogRepositoryReadOnly, QueryLogRepositoryReadOnly>();

            serviceCollection.AddScoped<IBillingAttributeRepositoryReadOnly, BillingAttributeRepositoryReadOnly>();
            serviceCollection.AddScoped<IBillingAttributeRepository, BillingAttributeRepository>();
            serviceCollection.AddScoped<IBillingPlanRepositoryReadOnly, BillingPlanRepositoryReadOnly>();
            serviceCollection.AddScoped<IBillingPlanRepository, BillingPlanRepository>();
            serviceCollection.AddScoped<IPlanAttributeRepositoryReadOnly, PlanAttributeRepositoryReadOnly>();
            serviceCollection.AddScoped<IPlanAttributeRepository, PlanAttributeRepository>();

            serviceCollection.AddScoped<IReportRepositoryReadOnly, ReportRepositoryReadOnly>();
        }
    }
}