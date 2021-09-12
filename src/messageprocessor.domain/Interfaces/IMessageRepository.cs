using MessageProcessor.Domain.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageProcessor.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateAsync(Message message);
        Task<List<Message>> GetAllAsync();
    }
}
