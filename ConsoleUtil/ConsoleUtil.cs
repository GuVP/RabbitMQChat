namespace Util
{
    public static class ConsoleUtil
    {
        private static ConsoleColor defaultColor => ConsoleColor.White;


        public static void ChangeFontColor(ConsoleColor fontColor)
        {
            Console.ForegroundColor = fontColor;
        }

        public static void WriteWarningMessage(string text)
        {
            ConsoleUtil.ChangeFontColor(ConsoleColor.Red);
            Console.WriteLine(text);
            ChangeFontColor(defaultColor);
        }

        public static void WriteReceivedMessage(string text)
        {
            ConsoleUtil.ChangeFontColor(ConsoleColor.Blue);
            Console.WriteLine(text);
            ChangeFontColor(defaultColor);
        }

        public static string InputMessage()
        {
            ConsoleUtil.ChangeFontColor(ConsoleColor.Green);
            return Console.ReadLine();
        }
    }
}