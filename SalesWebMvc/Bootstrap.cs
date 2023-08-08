using SalesWebMvc.Services;

namespace SalesWebMvc
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<SellerService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<SalesRecordService>();
        }
    }
}
