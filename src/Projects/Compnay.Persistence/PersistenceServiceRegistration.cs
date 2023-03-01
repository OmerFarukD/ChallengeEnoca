using Company.Application.Repositories;
using Compnay.Persistence.Contexts;
using Compnay.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Compnay.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("SqlCon")));
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICompanyRepository, CompanyRepository>();
        return services;
    }
}