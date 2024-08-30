using Application.Interfaces.IServices;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructures.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructures.Mappers;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection)
        {
            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddDbContext<InternshipProjectContext>(options =>
            {
                options.UseSqlServer(databaseConnection);
            });
            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);

            return services;
        }
    }
}
