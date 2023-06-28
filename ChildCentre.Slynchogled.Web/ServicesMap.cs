using ChildCentre.Slynchogled.Data.Context;
using ChildCentre.Slynchogled.Services.Interfaces;
using ChildCentre.Slynchogled.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace ChildCentre.Slynchogled.Web
{
    internal static class ServicesMap
    {
        internal static void AddServiceDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ChildCentreContext>(options
                => options.UseSqlite(builder.Configuration.GetValue<string>("ConnectionStrings:SQLite")), contextLifetime: ServiceLifetime.Singleton);

            builder.Services.AddSingleton<IClientsService, ClientsService>();
            builder.Services.AddSingleton<ICentreService, CentreService>();
            builder.Services.AddSingleton<ISettingsService, SettingsService>();
        }
    }
}