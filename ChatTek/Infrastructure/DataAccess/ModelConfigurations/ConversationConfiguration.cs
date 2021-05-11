using ChatTek.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatTek.Infrastructure.DataAccess.ModelConfigurations
{
    public sealed class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Conversations");

            builder.HasKey(b => b.Id);
        }
    }
}
