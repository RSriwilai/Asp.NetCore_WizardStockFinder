using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WizardStockFinder.DataAccess.DataContext;

var builder = new HostBuilder()
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<WizardStockFinderDbContext>(options =>
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("WizardStockFinderConnection")));

        // Register other services
        // ...
    });

using (var host = builder.Build())
{
    using (var serviceScope = host.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;
        var dbContext = services.GetRequiredService<WizardStockFinderDbContext>();

        dbContext.Database.Migrate();
    }

    host.Run();
}