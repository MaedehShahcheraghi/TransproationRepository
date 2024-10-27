using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation
{
    public static class ApplicationRegisterationService
    {
        public static IServiceCollection ApllicationServiceConfiguration(this IServiceCollection services) {

            #region AddAuotoMappper

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion
            #region AddMediatR

            services.AddMediatR(Assembly.GetExecutingAssembly());   

            #endregion


            return services;
        }
    }
}
