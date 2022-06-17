using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebNotes.Auth.Domain.Interfaces.Helper;
using WebNotes.Auth.Domain.Interfaces.Mapper;
using WebNotes.Auth.Domain.Interfaces.Repository;
using WebNotes.Auth.Domain.Interfaces.Services;
using WebNotes.Auth.Services.Helper;
using WebNotes.Auth.Services.Mapper;
using WebNotes.Auth.Services.Services;
using WebNotes.Infra.Repository;

namespace WebNotes.Auth.Api.Configuration
{
    public static class DependecyInjection
    {
        public static void AddDependencyInjections(this IServiceCollection services, ConfigurationManager configuration)
        {
            //Services
            services.AddScoped<IUserService, UserService>();

            //Mapper
            services.AddScoped<IUserMapper, UserMapper>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddSingleton<IConfiguration>(configuration);
        }

        public static void AddAuth(this IServiceCollection service, ConfigurationManager configuration)
        {
            service.AddAuthentication(options =>
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
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
        }
    }
}
