using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence;
using TransportationSystem.Applciation.Contracts.Persistence.CityRepository;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.Contracts.Persistence.PermissionRepository;
using TransportationSystem.Applciation.Contracts.Persistence.RoleRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepositories;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;
using TransportationSystem.Persistence.Context;
using TransportationSystem.Persistence.Repositories;
using TransportationSystem.Persistence.Repositories.CityRepositories;
using TransportationSystem.Persistence.Repositories.ComapanyRepositories;
using TransportationSystem.Persistence.Repositories.PermissionRepositories;
using TransportationSystem.Persistence.Repositories.RoleRepositories;
using TransportationSystem.Persistence.Repositories.UserRepositories;

namespace TransportationSystem.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection PersistenceServiceConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {

            #region AddTransportationDbContext
            services.AddDbContext<TransportationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TransportationConnectionString"));
            });
            #endregion
            #region Di
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ICityRepository), typeof(CityRepository));
            services.AddScoped(typeof(IStoreProcedureCreator), typeof(StoreProcedureCreator));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));
            services.AddScoped(typeof(IRoleRepositories), typeof(RoleRepository));
            services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
            services.AddScoped(typeof(IRolePermissionRepository), typeof(RolePermissionRepository));
            services.AddScoped(typeof(IUserCompanyRepository), typeof(UserCompanyRepository));
            #endregion
            return services;
        }
    }
}
