using System.Text;
using MerchantApp.Application.Extensions;
using MerchantApp.Domain.Entities;
using MerchantApp.Infrastructure.Extensions;
using MerchantApp.Infrastructure.Persistence.Data.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{


    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Enter your jwt token below"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});




IConfigurationSection jwtSettings = builder.Configuration.GetSection("Jwt");
string? secretKey = jwtSettings["Key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey ?? ""))
        };
    });




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger(c =>
{
    c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
}); app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
