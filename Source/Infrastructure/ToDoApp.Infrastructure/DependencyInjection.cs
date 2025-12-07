using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.UnitOfWork;
using Shared.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddToDoAppInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ToDoAppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ToDoAppConnection")));

            services.AddScoped<IUnitOfWork>(sp =>
            {
                var context = sp.GetRequiredService<ToDoAppDbContext>();
                return new UnitOfWork<ToDoAppDbContext>(context);
            });

            return services;
        }
    }
}
