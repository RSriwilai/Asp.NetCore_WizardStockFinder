﻿using Microsoft.AspNetCore.Cors.Infrastructure;
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
                .AddScoped<WizardStockFinderDbContext>()
                .AddScoped<IAccountService, AccountService>();
        }
    }
}
