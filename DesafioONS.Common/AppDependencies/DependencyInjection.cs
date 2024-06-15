using DesafioONS.Business.Services;
using DesafioONS.Business.Validations;
using DesafioONS.Entities.Abstractions;
using DesafioONS.Repository.Context;
using DesafioONS.Repository.Repositories;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DesafioONS.Common.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(
                    this IServiceCollection services,
                    IConfiguration configuration)
        {
            var connectionString = configuration
                                      .GetConnectionString("DefaultConnection");
           
            services.AddDbContext<AppDbContext>(options =>
                                  options.UseSqlServer(connectionString));

            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
                   

            var myhandlers = AppDomain.CurrentDomain.Load("DesafioONS.Business");
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(myhandlers);
                cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.Load("DesafioONS.Business"));     


            return services;
        }        
    }
}