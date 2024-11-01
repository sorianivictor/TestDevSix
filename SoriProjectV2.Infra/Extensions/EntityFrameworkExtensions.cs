using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoriProjectV2.Infra.Repositories;

namespace SoriProjectV2.Infra.Extensions;

public static class EntityFrameworkExtensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<AppContext>(x => x.UseNpgsql(connectionString));
        services.AddScoped<IVendaRepository, VendaRepository>()
            .AddScoped<IProdutoRepository, ProdutoRepository>();
        return services;
    }
}
