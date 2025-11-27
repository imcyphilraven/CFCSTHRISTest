using HRIS.Application.Common.Interfaces;
using HRIS.Infrastructure.Repositories.HRIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("HRISDb");
            services.AddDbContext<Persistence.HRISDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register Infrastructure services here

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            return services;
        }
    }
}
