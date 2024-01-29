using Apartment_Tracking_System.Application.Interfaces.Repositories;
using Apartment_Tracking_System.Persistence.Context;
using Apartment_Tracking_System.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration?.GetConnectionString("SQLConnection")));


            serviceCollection.AddTransient<IManagerService, ManagerRepository>();
            serviceCollection.AddTransient<IApartmentService, ApartmentRepository>();
            serviceCollection.AddTransient<IFlatService, FlatRepository>();
            serviceCollection.AddTransient<IDuesService, DuesRepository>();
            serviceCollection.AddTransient<ITenantService, TenantRepository>();
            return serviceCollection;
        }
    }
}
