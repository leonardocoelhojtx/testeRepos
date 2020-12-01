using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Private.Crosscuting.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Private.Data.Context;
using Private.Crosscuting.Mappings;
using Private.API.Filters;

namespace Private.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container. 
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MySqlConnection");
            var connectionReadOnlyString = Configuration.GetConnectionString("MySqlConnectionReadOnly");

            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services, connectionString, connectionReadOnlyString);

            var config = new AutoMapper.MapperConfiguration(cfg => {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // services.AddDbContext<PublicApiContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));
            services.AddControllers(options => {
                options.Filters.Add(new RequestFilters());
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(option => 
                option.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
