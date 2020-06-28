using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using utilitaire_stats_utilisation_ordi;

namespace workerService_utilitaire_stats
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private StateManager stateManager;
        private SaveManager saveManager;

        public Worker(ILogger<Worker> logger, IOptions<Options> options)
        {
            _logger = logger;
            stateManager = new StateManager();
            _logger.LogInformation("start worker with" + options.Value.DirectoryPath);
            saveManager = new SaveManager(options.Value.DirectoryPath);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("executeAsync");
            while (!stoppingToken.IsCancellationRequested)
            {
                stateManager.Update();
                saveManager.Update(stateManager.CurrentState);
                await Task.Delay(200, stoppingToken);
            }
        }
    }
}
