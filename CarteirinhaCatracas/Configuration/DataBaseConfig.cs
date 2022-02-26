using Microsoft.EntityFrameworkCore;

namespace CarteirinhaCatracas.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseCionfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Infrastructure.Data.AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Connection")));
        }

        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<Infrastructure.Data.AppDbContext>();
            //context.Database.Migrate();
            //context.Database.EnsureCreated();
        }
    }
}
