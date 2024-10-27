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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //Seed Data  
            builder.HasData(
                new Role()
                {
                    Id=1,
                    Role_Name = "Admin",
                    Role_Descreption = "this is admin"
                }
                );
        }
    }
}
