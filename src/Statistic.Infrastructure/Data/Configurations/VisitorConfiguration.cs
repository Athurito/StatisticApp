using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Statistic.Domain.Entities;

namespace Statistic.Infrastructure.Data.Configurations;

public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
{
    public void Configure(EntityTypeBuilder<Visitor> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasOne(v => v.Address)
            .WithMany(a => a.Visitors)
            .HasForeignKey(a => a.AddressId);
    }
}