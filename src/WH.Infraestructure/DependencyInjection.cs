using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WH.Application.Interfaces.Authentication;
using WH.Application.Interfaces.Services;
using WH.Infrastructure.Authentication;
using WH.Infrastructure.Persistence.Context;
using WH.Infrastructure.Persistence.Seeders;
using WH.Infrastructure.Services;

namespace WH.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            var assembly = typeof(ApplicationDbContext).Assembly.FullName;

            //services.AddDbContext<ApplicationDbContext>(
            //options => options
            //    .UseSqlServer(configuration.GetConnectionString("IdentityConnection"), b => b.MigrationsAssembly(assembly)));
            services.AddDbContext<ApplicationDbContext>(
            options => options
             .UseMySQL(configuration.GetConnectionString("DefaultConnection")!, b => b.MigrationsAssembly(assembly)));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IOrderingQuery, OrderingQuery>();

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            services.AddScoped<IPermissionService, PermissionService>();
            return services;
        }
    }
}
