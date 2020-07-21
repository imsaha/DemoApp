using DemoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoApp.Infrastructure.EntitiesConfigurations
{
    public class IdNameConfiguration : IEntityTypeConfiguration<IdName>
    {
        public void Configure(EntityTypeBuilder<IdName> builder)
        {
            builder.ToTable("tblTypes");
            builder.HasDiscriminator(x => x.Discriminator)
                .HasValue<Department>("Department");
        }
    }
}
