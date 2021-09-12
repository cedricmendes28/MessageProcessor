using MessageProcessor.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageProcessor.Infrastructure.EntityConfiguration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages")
                .HasKey(m => m.Id);

            builder.Property(m => m.Input)
                .IsRequired();
        }
    }
}
