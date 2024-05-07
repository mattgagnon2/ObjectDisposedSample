using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace ObjectDisposedSample;

public partial class MainViewModel : ObservableObject
{
	private readonly ILogger<MainViewModel> _logger;
    private readonly IBattery _battery;

    public MainViewModel(ILogger<MainViewModel> logger, IBattery battery)
	{
		_logger = logger;
		_battery = battery;

        battery.BatteryInfoChanged
            += Battery_BatteryInfoChanged;

        BatteryLevel = $"Battery Level: {_battery.ChargeLevel}";
        BatteryState = $"Battery State: {_battery.State}";
        PowerSource = $"Power Source: {_battery.PowerSource}";
        EnergySaverStatus = $"Energy Saver Status: {_battery.EnergySaverStatus}";
    }

    private void Battery_BatteryInfoChanged(
        object? sender, BatteryInfoChangedEventArgs e)
    {
        _logger.LogInformation("Battery info changed");
        _logger.LogInformation("Battery level: {level}", _battery.ChargeLevel);
        _logger.LogInformation("Battery State: {state}", _battery.State);
        _logger.LogInformation("Battery Source: {source}", _battery.PowerSource);
        _logger.LogInformation("Battery Saver: {status}", _battery.EnergySaverStatus);
        BatteryLevel = $"Battery Level: {_battery.ChargeLevel}";
        BatteryState = $"Battery State: {_battery.State}";
        PowerSource = $"Power Source: {_battery.PowerSource}";
        EnergySaverStatus = $"Energy Saver Status: {_battery.EnergySaverStatus}";
    }

    [ObservableProperty]
	string batteryLevel;

    [ObservableProperty]
    string batteryState;

    [ObservableProperty]
    string powerSource;

    [ObservableProperty]
    string energySaverStatus;
}

