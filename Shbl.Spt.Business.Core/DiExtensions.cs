using Microsoft.Extensions.DependencyInjection;
using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Business.Core.Services;

namespace Shbl.Spt.Business.Core;

public static class DiExtensions
{
    public static void AddBusiness(this IServiceCollection services)
    {
        services.AddScoped<ICfTypeService, CfTypeService>();
        services.AddScoped<ISeedDataService, SeedDataService>();
        services.AddScoped<IUserActivityService, UserActivityService>();
        services.AddScoped<IUserService, UserService>();
    }
}