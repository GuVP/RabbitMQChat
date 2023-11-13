namespace Util
{
    public static class ConsoleUtil
    {
        private static ConsoleColor defaultColor => ConsoleColor.White;
        private static ConsoleColor previousConsoleForegroundColor {  get; set; }

        private static void ChangeFontColor(ConsoleColor fontColor)
        {
            previousConsoleForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = fontColor;
        }

        private static void SetPreviousForegroundColor()
        {
            Console.ForegroundColor = previousConsoleForegroundColor;
        }

        public static void WriteWarningMessage(string text)
        {
            ChangeFontColor(ConsoleColor.Red);
            Console.WriteLine(text);
            SetPreviousForegroundColor();

        }

        public static void WriteReceivedMessage(string text)
        {
            ChangeFontColor(ConsoleColor.Blue);
            Console.WriteLine(text);
            SetPreviousForegroundColor();
        }

        public static string InputMessage()
        {
            ChangeFontColor(ConsoleColor.Green);
            var message = Console.ReadLine();
            SetPreviousForegroundColor();
            return message;
        }
    }
}