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

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDbContext<ServiTurnosDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("ServiTurnosDbConnection")));
        builder.Services.Configure<AuthenticationServiceOptions>(builder.Configuration.GetSection("AuthenticationServiceOptions"));

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

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}