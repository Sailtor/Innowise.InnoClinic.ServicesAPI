using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using UseCases.Interfaces;

namespace Infrastructure.MessageBus
{
    public class RabbitMQServicesProducer : IMessageProducer
    {
        private readonly string _hostname;
        private readonly string _queueName;

        public RabbitMQServicesProducer(IConfiguration configuration)
        {
            _hostname = configuration.GetRequiredSection("RabbitMQ:Hostname").Value;
            _queueName = configuration.GetRequiredSection("RabbitMQ:QueueName").Value;
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = _hostname };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: _queueName, body: body);
        }
    }
}
