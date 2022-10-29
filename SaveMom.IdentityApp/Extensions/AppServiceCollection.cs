using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaveMom.IdentityApp.Configurations;
using SaveMom.IdentityApp.Models;
using SaveMom.IdentityApp.Services;

namespace SaveMom.IdentityApp.Extensions
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            AddAppIdentity(services);
            AddDbServices(services, configuration);

            AddServices(services, configuration);

            AddOptions(services, configuration);

            return services;
        }
        
        private static void AddServices(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void AddOptions(IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        }
        private static void AddAppIdentity(IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<AppDbContext>();
        }

        private static void AddDbServices(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(
                o => o.UseSqlServer(configuration.GetConnectionString("LocalDb")));
        }

    }
}
