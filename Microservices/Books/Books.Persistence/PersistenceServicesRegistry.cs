using Books.Application.Contracts.Persistence;
using Books.Application.Contracts.Repositories;
using Books.Persistence.Repositories;
using Books.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Persistence
{
    public static class PersistenceServicesRegistry
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("MyConnection"));
            });

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();

            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            return services;
        }
    }
}