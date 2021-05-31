using Domain.Participants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.ModelConfigurations
{
    public sealed class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participants");

            builder.HasKey(b => b.Id);

            builder.OwnsOne(m => m.FullName, a =>
            {
                a.Property(p => p.FirstName).HasMaxLength(64)
                    .HasColumnName("FullNameFirstName");
                a.Property(p => p.LastName).HasMaxLength(64)
                    .HasColumnName("FullNameLastName");
            });
        }
    }
}
