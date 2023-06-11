using Microsoft.AspNetCore.Cors.Infrastructure;
using WizardStockFinder.BusinessLogic.Indicators;
using WizardStockFinder.BusinessLogic.Interfaces;
using WizardStockFinder.BusinessLogic.Services;
using WizardStockFinder.DataAccess.DataContext;
using WizardStockFinder.DataAccess.Interfaces;
using WizardStockFinder.DataAccess.Repositories;

namespace WizardStockFinder.WebApi.App_Start
{
    public static class ServiceLoader
    {
        public static void LoadServices(this IServiceCollection services)
        {
            services
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<ISubscriptionRepository, SubscriptionRepository>()
                .AddScoped<WizardStockFinderDbContext>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IScreenerService, ScreenerService>()
                .AddScoped<ISubscriptionService, SubscriptionService>()
                .AddScoped<ISupportResistanceIndicator, SupportResistanceIndicator>();
        }
    }
}
