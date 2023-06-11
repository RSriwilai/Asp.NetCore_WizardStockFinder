using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.Services.Workers;

namespace WizardStockFinder.Services.Extensions
{
    public static class ServicesHostExtensions
    {
        public static void AddTimedTask<TService>(this IServiceCollection services, Action<TimedTaskOptions<TService>> config)
        {
            var options = new TimedTaskOptions<TService>();
            config(options);
            services.AddHostedService(x => new TimedTaskWorker<TService>(
                x.GetService<IServiceScopeFactory>(),
                options
                , x.GetService<ILogger<TimedTaskWorker<TService>>>()
                ));
        }
    }
}
