using Application.Interfaces;
using Application.Models.Helpers;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Data;
using Infrastructure.ThirdServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuración de controladores con opciones JSON
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.WriteIndented = true;
            });

        builder.Services.AddEndpointsApiExplorer();

        // Configuración de DbContext
        builder.Services.AddDbContext<ServiTurnosDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("ServiTurnosDbConnection")));

        // Configuración de autenticación
        builder.Services.Configure<AuthenticationServiceOptions>(builder.Configuration.GetSection("AuthenticationServiceOptions"));

        // Configuración de Swagger
        builder.Services.AddSwaggerGen(setupAction =>
        {
            setupAction.AddSecurityDefinition("ServiTurnosApiBearerAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Description = "Please, paste the token to login for use all endpoints."
            });

            setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ServiTurnosApiBearerAuth"
                        }
                    },
                    new List<string>()
                }
            });
        });

        // Configuración de autenticación con JWT
        builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["AuthenticationServiceOptions:Issuer"],
                    ValidAudience = builder.Configuration["AuthenticationServiceOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AuthenticationServiceOptions:SecretForKey"]!))
                };
            }
        );

        // Configuración de CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
        });

        // Configuración de políticas de autorización
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("CustomerOnly", policy => policy.RequireClaim("TypeCustomer", "Customer"));
            options.AddPolicy("ProfessionalOnly", policy => policy.RequireClaim("TypeCustomer", "Professional"));
            options.AddPolicy("SuperAdminOnly", policy => policy.RequireClaim("TypeCustomer", "SuperAdmin"));

            options.AddPolicy("CustomerOrSuperAdmin", policy =>
            policy.RequireAssertion(context =>
            context.User.HasClaim("TypeCustomer", "Customer") ||
            context.User.HasClaim("TypeCustomer", "SuperAdmin")));

            options.AddPolicy("ProfessionalOrSuperAdmin", policy =>
            policy.RequireAssertion(context =>
                context.User.HasClaim("TypeCustomer", "Professional") ||
                context.User.HasClaim("TypeCustomer", "SuperAdmin")));

            options.AddPolicy("CustomerOrProfessionalOrSuperAdmin", policy =>
            policy.RequireAssertion(context =>
                  context.User.HasClaim("TypeCustomer", "Customer") ||
                  context.User.HasClaim("TypeCustomer", "Professional") ||
                  context.User.HasClaim("TypeCustomer", "SuperAdmin")));
        });

        // Configuración de servicios de aplicación e infraestructura
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
        builder.Services.AddScoped<IProfessionalService, ProfessionalService>();
        builder.Services.AddScoped<IMeetingService, MeetingService>();
        builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ISuperAdminService, SuperAdminService>();
        builder.Services.AddScoped<ISuperAdminRepository, SuperAdminRepository>();

        var app = builder.Build();

        // Configuración de middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        // Habilitación de CORS
        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
