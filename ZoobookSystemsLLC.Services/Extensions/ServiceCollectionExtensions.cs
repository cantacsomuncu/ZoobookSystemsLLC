using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using ZoobookSystemsLLC.Data.Abstract;
using ZoobookSystemsLLC.Data.Concrete;
using ZoobookSystemsLLC.Data.Concrete.EntityFramework.Contexts;
using ZoobookSystemsLLC.Entities.Concrete;
using ZoobookSystemsLLC.Services.Abstract;
using ZoobookSystemsLLC.Services.Concrete;

namespace ZoobookSystemsLLC.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString, string validAudience, string validIssuer, string JWTKey)
        {
            serviceCollection.AddDbContext<ZoobookSystemsLLCDbContext>(options => options.UseSqlServer(connectionString));

            // For Identity  
            serviceCollection.AddIdentity<User, Role>()
                            .AddEntityFrameworkStores<ZoobookSystemsLLCDbContext>()
                            .AddDefaultTokenProviders();
            // Adding Authentication  
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                        // Adding Jwt Bearer  
                        .AddJwtBearer(options =>
                        {
                            options.SaveToken = true;
                            options.RequireHttpsMetadata = false;
                            options.TokenValidationParameters = new TokenValidationParameters()
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidAudience = validAudience,
                                ValidIssuer = validIssuer,
                                ClockSkew = TimeSpan.Zero,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey))
                            };
                        });


            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IEmployeeService, EmployeeManager>();
            serviceCollection.AddScoped<IJWTService, JWTManager>();


            return serviceCollection;
        }
    }
}
