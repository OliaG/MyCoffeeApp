
using CommunityToolkit.Maui;
using MonkeyCache.FileStore;
using MyCoffeeApp.Helpers;
using MyCoffeeApp.Services;

namespace MyCoffeeApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("CustomFont.ttf", "AC");
                fonts.AddFont("fa-regular-400.ttf", "FAR");
                fonts.AddFont("fa-solid-900.ttf", "FAS");
                fonts.AddFont("fa-brands-400.ttf", "FAB");
            })
            .RegisterAppServices();


        return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ICoffeeService, CoffeeService>();

        return mauiAppBuilder;
    }
}
