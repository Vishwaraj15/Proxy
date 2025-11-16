using Microsoft.Extensions.DependencyInjection;
using MyOrganizationApp.Application.Common.Interfaces;
using MyOrganizationApp.Application.DTOs;
using MyOrganizationApp.Application.Services.Implementation;
using MyOrganizationApp.Application.Services.Interface;
using MyOrganizationApp.Infrastructure.Repository;

namespace MyOrganizationApp.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Register the generic read-only repository interface and implementation
            // The constraint on TView is applied here.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<DepartmentMapper>();

            services.AddScoped<ILookupService, LookupService>();

            //services.AddScoped(typeof(IGenericViewRepository<>), typeof(GenericViewRepository<>));

            // ... other services like DbContext registration

            return services;
        }
    }
}
