using BLL.Services;
using BLL.Services.Impl;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public class Configurations
    {
        public Configurations()
        {

        }
        public static void configureDependencies(IServiceCollection services)
        {
            //services.AddDbContext<DatabaseContext>(opts => opts.UseInMemoryDatabase("database"));
            services.AddScoped<DatabaseContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
