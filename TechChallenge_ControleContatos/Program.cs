using Npgsql;
using System.Configuration;
using System.Data;
using TechChallenge_ControleContatos.Infra.Mapping;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service.Interface;
using TechChallenge_ControleContatos.Service.Service;

namespace TechChallenge_ControleContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add db service injection
            var connectionstring = configuration.GetValue<string>("ConnectionStringPostgres");
            builder.Services.AddScoped<IDbConnection>((connection) => new NpgsqlConnection(connectionstring));

            builder.Services.AddScoped<IContactsService, ContactsService>();
            builder.Services.AddScoped<IContactsRepository, ContactsRepository>();

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
