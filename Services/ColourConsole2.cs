using System;
using System.Text;

namespace PyaFramework.Services
{
    public static partial class ColourConsole
    {
        public static int GetChoice(ConsoleColor colour, string[] options)
        {
            for (var index = 0; index < options.Length; index++)
            {
                Write(colour, $"Press {index + 1}: {options[index]}");
                SkipLine();
            }
            int input;
            do
                int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input);
            while ((1 <= input && input <= options.Length) == false);
            return input;
        }

        public static void Log(byte[] bytes, ConsoleColor colour = ConsoleColor.Green)
        {
            var stringWriter = new StringBuilder(bytes.Length * 3);
            foreach (var b in bytes)
                stringWriter.Append($"{b:X2} ");
            Log(colour, stringWriter.ToString().Trim());
        }
    }
}
