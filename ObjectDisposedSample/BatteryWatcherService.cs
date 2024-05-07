using System;
using Microsoft.Extensions.Logging;

namespace ObjectDisposedSample;

public interface IBatteryWatcherService
{

}

public class BatteryWatcherService : IBatteryWatcherService
{
    private readonly IBattery _battery;
    private readonly ILogger<BatteryWatcherService> _logger;

    public BatteryWatcherService(IBattery battery, ILogger<BatteryWatcherService> logger)
	{
        _battery = battery;
        _logger = logger;

        battery.BatteryInfoChanged
            += Battery_BatteryInfoChanged;
    }

    private void Battery_BatteryInfoChanged(
        object? sender, BatteryInfoChangedEventArgs e)
    {
        _logger.LogInformation("Battery info changed");
        _logger.LogInformation("Battery level: {level}", _battery.ChargeLevel);
        _logger.LogInformation("Battery State: {state}", _battery.State);
        _logger.LogInformation("Battery Source: {source}", _battery.PowerSource);
        _logger.LogInformation("Battery Saver: {status}", _battery.EnergySaverStatus);
    }
}

