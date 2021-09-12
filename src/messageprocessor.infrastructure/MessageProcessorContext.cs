using MessageProcessor.Domain.DomainModels;
using MessageProcessor.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessor.Infrastructure
{
    public class MessageProcessorContext : DbContext
    {
        public MessageProcessorContext(DbContextOptions<MessageProcessorContext> options)
            : base (options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Message> Messages { get; set; }
    }
}
