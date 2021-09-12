using MessageProcessor.Domain.DomainModels;
using MessageProcessor.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageProcessor.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageProcessorContext _dbContext;
        public MessageRepository(
            MessageProcessorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Message message)
        {
            await _dbContext.Messages.AddAsync(message);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await _dbContext.Messages
                .Select(m => m)
                .ToListAsync();
        }
    }
}
