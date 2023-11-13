using ChatManager.Model;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ChatManager 
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            List<OpenedChat> openChats = new List<OpenedChat>();

            Guid userId = Guid.NewGuid();

            Console.WriteLine("Welcome for P2P chat. Have a good and secure talk.");

            Console.WriteLine($"Here is your section user id: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{userId}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" \n ATTENTION: It's the way another user will establish a communication with you.\n");

            Console.WriteLine("Use one of the options below for more instructions: \n" +
                "'new chat' to start a new conversation \n" +
                "'help' to see all commands \n" +
                "'exit' to quit");

            string command = string.Empty;

            while (command != null)
            {
                command = Console.ReadLine();

                switch (command)
                {
                    case "help":
                        Console.WriteLine("The P2P chat is a console application used for talk with another person using his identification");
                        break;

                    case "exit":
                        Console.WriteLine("P2P chat will not persist any kind of communication. Are you sure that you wanna go? [y/n]");
                        var choice = Console.ReadLine();
                        if (choice.Equals("y"))
                        {
                            Console.WriteLine("Okay. Good bye!");
                            Thread.Sleep(2000);
                            Process.GetCurrentProcess().Kill();
                        }
                        break;

                    case "new chat":
                        Console.WriteLine("Digite o userId do destinatário:");
                        string targetUserId = Console.ReadLine();
                        if (!string.IsNullOrEmpty(targetUserId))
                        {
                            var processStartInfo = new ProcessStartInfo()
                            {
                                FileName = "ChatWindow",
                                UseShellExecute = true,
                                CreateNoWindow = false,
                                WindowStyle = ProcessWindowStyle.Normal,
                                ArgumentList =
                                {
                                    userId.ToString(),
                                    targetUserId
                                }
                            };

                            Process chatWindow = Process.Start(processStartInfo);

                            openChats.Add(new OpenedChat()
                            {
                                ChatWindow = chatWindow,
                                TargetId = targetUserId
                            });
                        }
                        else
                        {
                            Console.WriteLine("Its not a valid Target User ID.");
                        }
                        
                        break;
                }
            }
        }
    }
}
