using ChatWindow.MQServices;
using System;
using System.Diagnostics;
using System.Reflection;
using Util;

namespace ChatWindow
{
    public class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();

            if (args.Length == 2)
            {
                receiver.StartConsumer(args);
                Sender sender = new Sender(args);
                ChatWriter(sender);

                receiver.StopConsumer();                
            }
        }

        private static void ChatWriter(Sender sender)
        {
            var entrada = string.Empty;
            do
            {
                ConsoleUtil.InputMessage();
                sender.SendMessage(entrada);
            }
            while (entrada != "--exit");
        }
    }
}