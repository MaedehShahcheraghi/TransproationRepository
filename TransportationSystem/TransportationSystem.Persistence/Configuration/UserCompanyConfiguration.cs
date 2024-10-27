using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Domain.Entities.TransportCompanyEntities;

namespace TransportationSystem.Persistence.Configuration
{
    public class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
    {
        public void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            builder.HasOne(c => c.User).WithMany(c => c.UserCompanies).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.TransportCompany).WithMany(c => c.UserCompanies).HasForeignKey(c => c.CompanyId);
            builder.HasKey(c => new { c.UserId, c.CompanyId });
        }
    }
}
