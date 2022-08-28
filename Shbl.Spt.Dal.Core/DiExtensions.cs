using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shbl.Spt.Dal.Core.Context;

namespace Shbl.Spt.Dal.Core;

public static class DiExtensions
{
    public static void AddDal(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SptContext>(options => options.UseSqlServer(connectionString));
    }
}