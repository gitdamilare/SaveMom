using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SaveMom.Contracts.Configurations;
using SaveMom.Domain.Identity;
using System.Text;

namespace SaveMom.API.Extentions
{
    public static class RegisterServiceExtention
    {
        public static IServiceCollection AddAppCors(this IServiceCollection services, string corsPolicyName)
        {
            services.AddCors(o =>
            {
                o.AddPolicy(name : corsPolicyName, b => b.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            return services;
        }

        public static IServiceCollection AddAppAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(c =>
            {
                c.RequireHttpsMetadata = false;
                c.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };
            });

            return services;
        }

        public static IServiceCollection AddAppAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(o =>
            {
                o.AddPolicy("AdminPolicy", p =>
                {
                    p.RequireClaim("Access", "ViewOrganisation");
                });
            });

            return services;
        }

        public static IServiceCollection AddAppIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoDbSettings = configuration.GetSection(DbStoreOptions.SectionName).Get<DbStoreOptions>();

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            }).AddMongoDbStores<AppUser, AppRole, Guid>(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName);

            return services;
        }

        public static IServiceCollection AddAppOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbStoreOptions>
                (configuration.GetSection(DbStoreOptions.SectionName));

            services.Configure<JwtOptions>
                (configuration.GetSection(JwtOptions.SectionName));

            services.Configure<AzureBlobStorageOptions>
                (configuration.GetSection(AzureBlobStorageOptions.SectionName));
            return services;
        }
    }
}
