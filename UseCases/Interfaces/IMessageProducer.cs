namespace UseCases.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
