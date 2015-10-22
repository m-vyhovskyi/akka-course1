using System;

namespace AkkaLearning.Common
{
    public static class ColorConsole
    {
        private static void WriteLine(ConsoleColor color, string message)
        {
            var beforeColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineGreen(string message)
        {
            WriteLine(ConsoleColor.Green, message);
        }

        public static void WriteLineYellow(string message)
        {
            WriteLine(ConsoleColor.Yellow, message);
        }

        public static void WriteLineRed(string message)
        {
            WriteLine(ConsoleColor.Red, message);
        }

        public static void WriteLineCyan(string message)
        {
            WriteLine(ConsoleColor.Cyan, message);
        }

        public static void WriteLineGray(string message)
        {
            WriteLine(ConsoleColor.Gray, message);
        }

        public static void WriteMagenta(string message)
        {
            WriteLine(ConsoleColor.Magenta, message);
        }
    }
}