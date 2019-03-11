using Easycom.Core.Interfaces;
using Easycom.Core.Interfaces.Repository;
using Easycom.Core.Services;
using Easycom.Data.EF.Data;
using Easycom.Data.EF.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Easycom.Infrastructure.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

            var connectionString = configuration.GetConnectionString("StringConnection");

            services.AddDbContext<AppContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
