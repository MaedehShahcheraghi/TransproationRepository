using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.UserEntities;

namespace TransportationSystem.Persistence.Configuration
{
    public class RolePermissionConfigurations : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasOne(c => c.Permission).WithMany(c => c.RolePermissions).HasForeignKey(c => c.Permission_Id);
            builder.HasOne(c => c.Role).WithMany(c => c.RolePermissions).HasForeignKey(c => c.Role_Id);
            builder.HasKey(c => new { c.Role_Id, c.Permission_Id });

        }
    }
}
