using CA.Core.Interfaces;
using CA.Infrastructure.Repositories;

namespace CA.API.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependecy(this IServiceCollection services)
        {
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();
            //services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
