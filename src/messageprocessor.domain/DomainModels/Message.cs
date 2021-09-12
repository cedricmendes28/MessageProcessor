namespace MessageProcessor.Domain.DomainModels
{
    public class Message
    {
        public int Id { get; private set; }

        public string Input { get; private set; }

        private Message() { }

        public Message(string input)
        {
            Input = input;
        }
    }
}
