using NHibernateSample.Application.Interfaces;
using NHibernateSample.Application.Mappers;
using NHibernateSample.Business.Interfaces;
using NHibernateSample.Business.Services;
using NHibernateSample.Domain.Repositories;
using AutoMapper;
using NHibernateSample.Api.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Keycloak.AuthServices.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookMapper, BookMapper>();
builder.Services.AddScoped<IBookService, BookService>();
var authenticationOptions = new KeycloakAuthenticationOptions
{
    AuthServerUrl = "http://localhost:8080/",
    Realm = "Test",
    Resource = "test-client",
    SslRequired = "none",
    VerifyTokenAudience = false
};
builder.Services.AddKeycloakAuthentication(authenticationOptions);
builder.Services.AddSwaggerGen(c =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer", // must be lower case
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, Array.Empty<string>()}
            });
        });
var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();

// curl --data "grant_type=password&client_id=test-client&username=myuser&password=test&client_secret=rGo7MLFtGb86YRsTGKZcYHE37hPtc1RM" \
//     localhost:8080/realms/Test/protocol/openid-connect/token