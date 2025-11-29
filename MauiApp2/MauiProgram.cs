using MauiApp2.Data;
using MauiApp2.Services;
using Microsoft.Extensions.Logging;

namespace MauiApp2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            var mongoSettings = new MongoDbSettings
            {
                 ConnectionString= "mongodb://localhost:27017/",
                 DatabaseName="mirchiApp"
            };
            builder.Services.AddSingleton(mongoSettings);
            builder.Services.AddSingleton<MongoDbService>();
            builder.Services.AddSingleton<UserService>();
            return builder.Build();
        }
    }
}
