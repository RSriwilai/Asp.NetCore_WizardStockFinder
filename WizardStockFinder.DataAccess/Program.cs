using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using WizardStockFinder.DataAccess.DataContext;

var builder = new HostBuilder()
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.SetBasePath(hostContext.HostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton<WizardStockFinderDbContext>();

        // Register other services

    });

var host = builder.Build();