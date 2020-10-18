using System;

namespace MyConsole
{
    public static class Log
    {
        public static void Print(string message)
        {
            Console.Write(message);
        }
        
        public static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Print(message);
            Console.ResetColor();
        }
        
        public static void PrintSexy(string sexyMessage)
        {
            Print(sexyMessage, ConsoleColor.DarkMagenta);
        }
        
        public static void PrintGray(string sexyMessage)
        {
            Print(sexyMessage, ConsoleColor.Gray);
        }

        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
        
        public static void PrintLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            PrintLine(message);
            Console.ResetColor();
            Print("");
        }

        public static void PrintLineSexy(string sexyMessage)
        {
            PrintLine(sexyMessage, ConsoleColor.DarkMagenta);
        }

        public static void PrintLineError(string message)
        {
            PrintLine(message, ConsoleColor.Red);
        }
        
        public static void PrintLineContrast(string sexyMessage)
        {
            PrintLine(sexyMessage, ConsoleColor.Blue);
        }
        
        public static void PrintLineGray(string sexyMessage)
        {
            PrintLine(sexyMessage, ConsoleColor.Gray);
        }

        public static void NewLine()
        {
            PrintLine("");
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        public static void ParseInt(Action<int> onIntParse)
        {
            int n;
            if (int.TryParse(ReadLine(), out n))
                onIntParse?.Invoke(n);
        }
    }
}