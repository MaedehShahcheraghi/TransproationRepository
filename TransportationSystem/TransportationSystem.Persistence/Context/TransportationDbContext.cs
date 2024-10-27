using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.Citites;
using TransportationSystem.Domain.Entities.Common;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;
using TransportationSystem.Domain.Entities.UserEntities;
using TransportationSystem.Domain.Entities.UserEntity;

namespace TransportationSystem.Persistence.Context
{
    public class TransportationDbContext: DbContext
    {
        public TransportationDbContext(DbContextOptions<TransportationDbContext> options):base(options) 
        {
                
        }


        #region DbSet city
        public DbSet<City> Cities { get; set; }

        #endregion
        #region Dbset Users

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> rolePermissions { get; set; }
        #endregion
        #region Dbset Company
        public DbSet<TransportCompany> TransportCompanies { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransportationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        #region Configure SaveChanges
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
                if (entry.State != EntityState.Modified)
                {
                    entry.Entity.CreateDate = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
                if (entry.State != EntityState.Modified)
                {
                    entry.Entity.CreateDate = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();

        }
        #endregion


    }
}
