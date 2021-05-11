using ChatTek.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatTek.Infrastructure.DataAccess.ModelConfigurations
{
    public sealed class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participants");

            builder.HasKey(b => b.Id);

            builder.Property(p => p.FirstName)
                .HasMaxLength(64);

            builder.Property(p => p.LastName)
                .HasMaxLength(64);
        }
    }
}
