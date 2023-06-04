using WizardStockFinder.Services.Processors;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<StockHandlerProcessor>();
    })
    .Build();

host.Run();
