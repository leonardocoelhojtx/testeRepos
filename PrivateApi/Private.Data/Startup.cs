using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Private.Data.Context;
using Private.Domain.Interfaces.Services;
using Private.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Data
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("dbconfig.json", optional: false);

            Configuration = builder.Build();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigurationServices(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<PrivateApiContext>(options => options.UseMySql(connString));
        }
    }
}
