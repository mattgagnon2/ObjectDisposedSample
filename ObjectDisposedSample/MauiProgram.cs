using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Shiny;

namespace ObjectDisposedSample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
#if __MOBILE__
            .UseShiny()
#endif
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton(Battery.Default);
        builder.Services.AddTransientWithShellRoute<MainPage, MainViewModel>(nameof(MainPage));

		//if the following line is commented out, no crash should happen
        builder.Services.AddJob(typeof(EmptyStartupJob), nameof(EmptyStartupJob), runInForeground: true);

        return builder.Build();
	}
}

