using Microsoft.Extensions.DependencyInjection;
using Private.Domain.Interfaces.Services;
using Private.Service.Services;

namespace Private.Crosscuting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService (IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPersonService, PersonService> ();
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<IPartnerService, PartnerService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ITaxRegimeService, TaxRegimeService>();
            serviceCollection.AddTransient<IOperationNatureService, OperationNatureService>();
            serviceCollection.AddTransient<IOperationProfileService, OperationProfileService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<ITaxScenarioService, TaxScenarioService>();
            serviceCollection.AddTransient<IQueryLogService, QueryLogService>();
            serviceCollection.AddTransient<ISalesPlanService, SalesPlanService>();
            serviceCollection.AddTransient<IReportService, ReportService>();
        }
    }
}