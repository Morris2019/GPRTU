using Microsoft.Extensions.Logging;
using GPRTU.ViewModels;
using CommunityToolkit.Maui;
using The49.Maui.BottomSheet;

namespace GPRTU;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMaps()
            .UseMauiCommunityToolkit()
            .UseBottomSheet()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<LocationSheet>();
        builder.Services.AddTransient<BottomdrawerViewModel>();
        builder.Services.AddSingleton<IMap>(Map.Default);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

