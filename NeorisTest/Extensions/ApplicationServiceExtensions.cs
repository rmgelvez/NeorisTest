using Core.Interfaces;
using Infrastructura.UnitOfWork;
using Infrastructure.Repositories;

namespace NeorisTest.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfiggureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void AddAplicationServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
