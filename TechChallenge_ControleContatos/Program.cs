using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using System.Reflection;
using System.Text;
using TechChallenge_ControleContatos.Infra.Repository;
using TechChallenge_ControleContatos.JWT;
using TechChallenge_ControleContatos.Service.Interface;
using TechChallenge_ControleContatos.Service.Service;
using Prometheus;


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

            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretJWT"));

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Contacts Control", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization Header - used with Bearer Authentication.\r\n\r\n" +
                        "Enter 'Bearer' [space] and then your token in the field below.\r\n\r\n" +
                        "Example (without quotes): 'Bearer 12345abcdef'",

                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // Add db service injection
            var connectionstring = configuration.GetValue<string>("ConnectionStringPostgres");
            builder.Services.AddScoped<IDbConnection>((connection) => new NpgsqlConnection(connectionstring));

            builder.Services.AddScoped<IContactsService, ContactsService>();
            builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
            builder.Services.AddScoped<IUsersService, UserService>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IRegionsRepository, RegionsRepository>();
            builder.Services.AddScoped<IRegionsService, RegionsService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMetricServer();
            app.UseHttpMetrics();
            app.MapControllers();
            app.MapMetrics();
            app.Run();
        }
    }
}
