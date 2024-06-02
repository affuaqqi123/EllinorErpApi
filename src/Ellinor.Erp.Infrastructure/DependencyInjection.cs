using Ellinor.Erp.Application.Services.Interfaces;
using Ellinor.Erp.Domain.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ellinor.Erp.Domain.Entities;
using System.Data;
using Ellinor.Erp.Infrastructure;
using Ellinor.Erp.Domain.Repositories.Interfaces;
using System.Reflection;
using Ellinor.Erp.Shared.DTOs;
using FluentValidation;
using MediatR;
using Ellinor.Erp.Application.Behaviors;
using Blog.Application.Services.Interfaces;
using Ellinor.Erp.Infrastructure.Services;
using System.Data.SqlClient;
using Ellinor.Erp.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using Ellinor.Erp.Infrastructure.Repositories;


namespace Ellinor.Erp.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
              configuration.GetConnectionString("Ellinor.ErpComplaintConnectionString") ??
              throw new ArgumentNullException(nameof(configuration));
            services.AddTransient<IUnitOfWork, DapperUnitOfWork>(c => new DapperUnitOfWork(connectionString));
            services.AddSingleton(new DefaultSqlConnectionFactory(connectionString));

            services.AddScoped<IFileUploadingService, FileUploadingService>();

            services.AddTransient<IGenericInterface, CustomerComplaintRespository>();
          
            return services;
        }
    }
}
