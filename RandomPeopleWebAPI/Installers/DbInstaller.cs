using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomPeopleWebAPI.Models;
using System;

namespace RandomPeopleWebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<RandomPeopleDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(configuration.GetConnectionString("RandomPeople"), new MySqlServerVersion(new Version(8, 0, 21)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
        }
    }
}
