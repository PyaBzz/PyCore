using System;
using System.Text;

namespace PyaFramework.Services
{
    public static partial class ColourConsole
    {
        private static object _ResourceLock = new object();

        private static void Log(ConsoleColor colour, object message)
        {
            var text = message is string ? message : message.ToString();
            lock (_ResourceLock)
            {
                Console.ForegroundColor = colour;
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }

        public static void LogGreen(object message) => Log(ConsoleColor.Green, message);
        public static void LogYellow(object message) => Log(ConsoleColor.Yellow, message);
        public static void LogRed(object message) => Log(ConsoleColor.Red, message);
        public static void LogCyan(object message) => Log(ConsoleColor.Cyan, message);
        public static void LogMagenta(object message) => Log(ConsoleColor.Magenta, message);

        private static void Write(ConsoleColor colour, object message)
        {
            var text = message is string ? message : message.ToString();
            lock (_ResourceLock)
            {
                Console.ForegroundColor = colour;
                Console.Write(text);
                Console.ResetColor();
            }
        }

        public static void SkipLine() => Console.WriteLine();
    }
}
