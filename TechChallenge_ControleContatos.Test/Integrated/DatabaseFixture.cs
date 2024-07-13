using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Data;
using System.IO;
using TechChallenge_ControleContatos.Controllers;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.Service;
using TechChallenge_ControleContatos.Service.Interface;
using TechChallenge_ControleContatos.Service.Service;

public class DatabaseFixture : IDisposable
{
    public IContactsService ContactsService { get; private set; }
    public ILogger<ContactsInfoController> Logger { get; private set; }

    public DatabaseFixture()
    {
        // Load configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Initialize logger
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConfiguration(configuration.GetSection("Logging"));
            builder.AddConsole();
        });
        Logger = loggerFactory.CreateLogger<ContactsInfoController>();

        // Get the connection string from configuration
        var connectionString = configuration.GetValue<string>("ConnectionStringPostgres");

        // Initialize the IDbConnection
        IDbConnection dbConnection = new NpgsqlConnection(connectionString);

        // Initialize the repositories
        IUsersRepository usersRepository = new UsersRepository(dbConnection);
        IContactsRepository contactsRepository = new ContactsRepository(dbConnection, usersRepository);
        IRegionsRepository regionsRepository = new RegionsRepository(dbConnection);

        // Initialize the ContactsService
        ContactsService = new ContactsService(contactsRepository, regionsRepository);
    }

    public void Dispose()
    {
        // Clean up database or other resources here
    }
}
