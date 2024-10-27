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
    public class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(c=> c.user).WithMany(c=> c.UserRoles).HasForeignKey(c=> c.User_Id);
            builder.HasOne(c=> c.Role).WithMany(c=> c.UserRoles).HasForeignKey(c=> c.Role_Id);
            builder.HasKey(c => new { c.Role_Id, c.User_Id });
        }
    }
}
