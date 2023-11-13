using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace ChatWindow.MQServices
{
    public class Sender
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _targetId;

        public Sender(string[] userId)
        {
            _targetId = $"{userId[0]}:{userId[1]}";
            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
        }

        public void SendMessage(string message)
        {
            using (var connection = _connectionFactory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(_targetId, false, false, false, null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", _targetId, null, body);
            }
        }
    }
}
