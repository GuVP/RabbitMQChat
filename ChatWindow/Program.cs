using ChatWindow.MQServices;
using System.Diagnostics;

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
                sender.StartSender();

                sender.SendMessage();

                receiver.StopConsumer();

                Process.GetCurrentProcess().Kill();
            }
        }
    }
}