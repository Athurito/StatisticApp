using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Statistic.Domain.Entities;
using Statistic.Domain.Enums;

namespace Statistic.Infrastructure.Data.Configurations;

public class VisitorInterestsConfiguration : IEntityTypeConfiguration<VisitorInterests>
{
    public void Configure(EntityTypeBuilder<VisitorInterests> builder)
    {
        builder.HasKey(vi => new { vi.VisitorId, vi.Interest }); // Composite Key

        builder
            .HasOne(vi => vi.Visitor)
            .WithMany(v => v.VisitorInterests)
            .HasForeignKey(vi => vi.VisitorId);

        builder
            .Property(vi => vi.Interest)
            .HasConversion(
                v => v.ToString(),
                v => (Interests)Enum.Parse(typeof(Interests), v));
    }
}