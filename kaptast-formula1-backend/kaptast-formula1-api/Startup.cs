using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KaptastFormula1Api.Middlewares;
using KaptastFormula1Api.Repository;
using KaptastFormula1Api.Repository.Repositories;
using KaptastFormula1Api.Repository.Repositories.Interfaces;
using KaptastFormula1Api.Services.Interfaces;
using KaptastFormula1Api.Services.Services;
using KaptastFormula1Api.ViewModels.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace KaptastFormula1Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure AutoMapper with the Assembly where profiles are located
            services.AddAutoMapper(typeof(TeamProfile));

            // Set the CORS policy to allow any request
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            // Configure in memory SQLite Database with the correct database context
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            services.AddDbContext<FormulaDbContext>(options =>
            {
                options.UseSqlite(connection);
            });

            // Add Identity service and configure it to use the correct database context
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<FormulaDbContext>()
                .AddDefaultTokenProviders();

            // Configure password policy to allow the test password
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            // Configure JWT Bearer token handling
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Token").Value);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();

            // Register services
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FormulaDbContext db, IAuthService authService)
        {
            // Register the exception handling middleware
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // Create the database tables if they haven't been created yet.
            db.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Register test user
            authService.Register(new ViewModels.Models.UserViewModel { UserName = "admin", Password = "f1test2018" });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
