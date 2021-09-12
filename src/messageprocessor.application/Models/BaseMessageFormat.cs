using Newtonsoft.Json;

namespace MessageProcessor.Application.Models
{
    public abstract class BaseMessageFormat
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
