using CubosBankAPI.Api.Infra.IoC;
using CubosBankAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CubosBankAPI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /*
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<CubosBankDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("CubosBankDbConnection
            */
            builder.Services.AddInfrastructure(builder.Configuration);
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}