using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Data.EF.Extensions;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Data.EF.Configurations;

public class AdvertisementConfiguration : DbEntityConfiguration<Advertisement>
{
    public override void Configure(EntityTypeBuilder<Advertisement> entity)
    {
        entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
    }
}