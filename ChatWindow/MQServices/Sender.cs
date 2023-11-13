using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Util;

namespace ChatWindow.MQServices
{
    public class Sender
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _senderId;
        private IConnection _connection;
        private IModel _channel;

        public Sender(string[] userId)
        {
            _senderId = $"{userId[0]}:{userId[1]}";
            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
        }

        public void  StartSender()
        {
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void SendMessage()
        {
            using(_connection)
            using (_channel)
            {
                _channel.QueueDeclare(_senderId, false, false, false, null);

                var message = string.Empty;
                do
                {
                    message = ConsoleUtil.InputMessage();
                    var body = Encoding.UTF8.GetBytes(message);

                    _channel.BasicPublish("", _senderId, null, body);
                }
                while (message != "--exit");
            }
        }
    }
}
