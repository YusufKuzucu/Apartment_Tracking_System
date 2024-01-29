using Apartment_Tracking_System.Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection collection)
        {
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());
            return collection;  

        }
    }
}
