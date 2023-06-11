using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardStockFinder.Services.Workers
{
    public class TimedTaskOptions<TService>
    {
        public string Name { get; set; }
        public Func<TService, Task> TaskToRun { get; set; }
        public TimeSpan Timer { get; set; }
    }


    public class TimedTaskWorker<TService> : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly TimedTaskOptions<TService> _options;
        private readonly ILogger<TimedTaskWorker<TService>> _logger;

        public TimedTaskWorker(IServiceScopeFactory serviceScopeFactory, TimedTaskOptions<TService> options,
            ILogger<TimedTaskWorker<TService>> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _options = options;
            _logger = logger;

            _logger.LogInformation("{Name} worker spawned interval: {Timer}", _options.Name, options.Timer);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(_options.Timer);
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    _logger.LogInformation("Running task {Name}", _options.Name);
                    using var scope = _serviceScopeFactory.CreateScope();
                    var myService = scope.ServiceProvider.GetRequiredService<TService>();
                    await _options.TaskToRun(myService);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "");
                }

            }
        }
    }
}
