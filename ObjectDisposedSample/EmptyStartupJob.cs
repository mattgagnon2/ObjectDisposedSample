using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shiny.Jobs;

namespace ObjectDisposedSample;

public class EmptyStartupJob : Job
{
    // This job exists so that during app startup, the maui program can properly register all Shiny services into the DI container
    public EmptyStartupJob(ILogger<EmptyStartupJob> logger) : base(logger)
    {
    }

    protected override Task Run(CancellationToken cancelToken)
    {
        return Task.CompletedTask;
    }
}
