using WebNotes.Auth.Domain.Interfaces.Services;
using WebNotes.Auth.Services.Services;

namespace WebNotes.Auth.Api.Configuration
{
    public static class DependecyInjection
    {
        public static void AddDependencyInjections(this IServiceCollection services, ConfigurationManager configuration)
        {
            //Services
            services.AddScoped<IUserService, UserService>();
        }
    }
}
