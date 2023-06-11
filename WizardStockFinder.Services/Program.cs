using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using WizardStockFinder.DataAccess.DataContext;
using WizardStockFinder.Services.Extensions;
using WizardStockFinder.Services.Interfaces;
using WizardStockFinder.Services.Processors;
using WizardStockFinder.Services.Repositories;
using WizardStockFinder.Services.Repositories.Interfaces;
using WizardStockFinder.Services.Services;
using WizardStockFinder.Services.Services.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        services.AddScoped<IStockHandlerProcessor, StockHandlerProcessor>();
        services.AddScoped<WizardStockFinderDbContext>();
        services.AddScoped<IStockDataRepository, StockDataRepository>();
        services.AddScoped<IStockDataService, StockDataService>();
        
        
        services.AddTimedTask<IStockHandlerProcessor>(x =>
        {
            x.Timer = TimeSpan.FromSeconds(10);
            x.Name = nameof(IStockHandlerProcessor.ExecuteAsync);
            x.TaskToRun = handler => handler.ExecuteAsync();
        });
    })
    .Build();


host.Run();
