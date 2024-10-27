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
    public class CompanyConfiguration : IEntityTypeConfiguration<TransportCompany>
    {
        public void Configure(EntityTypeBuilder<TransportCompany> builder)
        {
            
        }
    }
}
