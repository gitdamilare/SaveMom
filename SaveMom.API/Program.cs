
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SaveMom.API.Configuration;
using SaveMom.API.Extentions;
using SaveMom.Contracts.Configurations;
using SaveMom.Services;

var AppCorsPolicy = "_appCorsPolicy";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IOrganisationService, OrganisationService>();

//Options
builder.Services.Configure<SaveMomStoreDatabaseOptions>
    (configuration.GetSection(SaveMomStoreDatabaseOptions.SectionName));
builder.Services.Configure<JwtOptions>
    (configuration.GetSection(JwtOptions.SectionName));

builder.Services.AddAppCors(AppCorsPolicy);
builder.Services.AddControllers(o =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    o.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAppAuthentication(configuration);
builder.Services.AddAppAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMvc();

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
