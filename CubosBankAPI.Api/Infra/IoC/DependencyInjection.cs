using CubosBankAPI.Application.Services;
using CubosBankAPI.Application.Services.Interfaces;
using CubosBankAPI.Domain.Repositories;
using CubosBankAPI.Infra.Data.Context;
using CubosBankAPI.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CubosBankAPI.Api.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CubosBankDbContext> (options =>
                           options.UseNpgsql(configuration.GetConnectionString("CubosBankDbConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CubosBankDbContext>(options =>
                           options.UseNpgsql(configuration.GetConnectionString("CubosBankDbConnection")));

            services.AddScoped<IPersonService, PersonService>();
            //services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<ICardService, CardService>();
            //services.AddScoped<ITransactionService, TransactionService>();

            return services;

        }


    }

}
