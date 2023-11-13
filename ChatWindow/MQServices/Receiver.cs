using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Util;

namespace ChatWindow.MQServices
{
    public class Receiver
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public Receiver()
        {
            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672/")
            };
        }

        public void StartConsumer(string[] userId)
        {
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            string queue = $"{userId[1]}:{userId[0]}";

            _channel.QueueDeclare(queue, false, false, false, null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += Consume;

            _channel.BasicConsume(queue, true, consumer);
        }

        public void StopConsumer()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        private void Consume(object? sender, BasicDeliverEventArgs ea)
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());

            if (message.Equals("--exit", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleUtil.WriteWarningMessage("The another user disconnected from P2P Chat.");
            }
            else
            {
                ConsoleUtil.WriteReceivedMessage(message);
            }
        }        
    }
}
