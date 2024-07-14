using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Data.EF.Extensions;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Data.EF.Configurations;

public class AdvertisementPageConfiguration : DbEntityConfiguration<AdvertistmentPage>
{
    public override void Configure(EntityTypeBuilder<AdvertistmentPage> entity)
    {
        entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
    }
}