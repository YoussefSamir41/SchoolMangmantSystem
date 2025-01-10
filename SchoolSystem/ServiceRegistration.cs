
using Data.Entities.Sec;
using Data.Helpers;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace SchoolSystem
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection service, IConfiguration configuration)
        {
            //service.AddIdentity<User, IdentityRole<int>>(option =>
            //{
            //    // Password settings.
            //    option.Password.RequireDigit = true;
            //    option.Password.RequireLowercase = true;
            //    option.Password.RequireNonAlphanumeric = true;
            //    option.Password.RequireUppercase = true;
            //    option.Password.RequiredLength = 6;
            //    option.Password.RequiredUniqueChars = 1;

            //    // Lockout settings.
            //    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    option.Lockout.MaxFailedAccessAttempts = 5;
            //    option.Lockout.AllowedForNewUsers = true;

            //    // User settings.
            //    option.User.AllowedUserNameCharacters =
            //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    option.User.RequireUniqueEmail = true;
            //    option.SignIn.RequireConfirmedEmail = true;

            //}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            service.AddIdentity<User, IdentityRole<int>>()
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();
            //JWT Authentication
            //JWT Authentication
            var jwtSettings = new JwtSettings();
            var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            service.AddSingleton(jwtSettings);
            service.AddSingleton(emailSettings);

            //Swagger Gn
            service.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School System", Version = "v1" });

                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return service;

        }
    }
}
