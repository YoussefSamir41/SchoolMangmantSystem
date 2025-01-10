using Core;
using Core.Middleware;
using Data.Entities.Sec;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Seeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service;
using System.Globalization;

namespace SchoolSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            #region Dependency Injections

            builder.Services
                 .AddInfrastructureDependencies()
                 .AddServiceDependencies()
                 .AddCoreDependencies()
            .AddServiceRegistration(builder.Configuration);


            #endregion






            #region Localization

            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(option =>
            {
                option.ResourcesPath = "";
            });

            builder.Services.Configure<RequestLocalizationOptions>(option =>
            {

                List<CultureInfo> supportCulture = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE") ,
                    new CultureInfo("fr_FR") ,
                    new CultureInfo("ar-Eg")
                };

                option.DefaultRequestCulture = new RequestCulture("ar-Eg");
                option.SupportedCultures = supportCulture;
                option.SupportedCultures = supportCulture;

            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("ar-Eg");
            });




            #endregion


            #region AllowCORS
            var CORS = "_cors";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CORS,
                                  policy =>
                                  {
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyOrigin();
                                  });
            });

            #endregion


            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.Services.AddScoped<IUrlHelper>(serviceProvider =>
            {
                var actionContext = serviceProvider.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = serviceProvider.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });


            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
                await RoleSeeder.SeedAsync(roleManager);
                await UserSeeder.SeedAsync(userManager);
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #region Localization
            var option = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(option.Value);
            #endregion


            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseCors(CORS);
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
