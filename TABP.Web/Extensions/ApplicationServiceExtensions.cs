using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MediatR;
using FluentValidation;
using TABP.Application.Behaviors;
using TABP.Application.Users.Register;
using TABP.Domain.Entities;
using TABP.Infrastructure;
using TABP.Web.Mapping;
using TABP.Infrastructure.Repositories;
using TABP.Domain.Interfaces.Repositories;
using TABP.Application.Mappings;

namespace TABP.Web.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(UserMapping).Assembly);
            services.AddAutoMapper(typeof(UserMappingProfile));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(UserCommand).Assembly));

            services.AddValidatorsFromAssembly(typeof(UserCommandValidator).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddDbContext<TABPDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        }
    }
}
