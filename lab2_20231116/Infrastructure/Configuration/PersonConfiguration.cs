using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lab2.Infrastructure.Entities;

namespace Lab2.Infrastructure.Configuration
{
    class PersonConfiguration
    {
        private void ConfigurePersonEntity(EntityTypeBuilder<PersonEntity> entity)
        {
            entity.ToTable("Person");

            entity.Property(p => p.FirstName).HasMaxLength(200).IsRequired();
            entity.Property(p => p.LastName).HasMaxLength(200).IsRequired();
        }
    }
}
