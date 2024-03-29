
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SaveMom.API.Extentions;
using SaveMom.Domain.Data;
using SaveMom.Services;
using SaveMom.Services.Identity;

var AppCorsPolicy = "_appCorsPolicy";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.
services.AddScoped(typeof(IDbContext<>), typeof(MongoDbContext<>));
services.AddScoped<IOrganisationService, OrganisationService>();
services.AddScoped<IAccountService, AccountService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<ITokenService, TokenService>();
services.AddScoped<IAzureBlobService, AzureBlobServices>();

//Options
services.AddAppOptions(configuration);

services.AddAppCors(AppCorsPolicy);

services.AddAppIdentity(configuration);

services.AddControllers(o =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    o.Filters.Add(new AuthorizeFilter(policy));
});

services.AddAppAuthentication(configuration);
services.AddAppAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AppCorsPolicy);
//app.UseApiResponseWrapper();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
