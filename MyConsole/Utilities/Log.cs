using System;

namespace MyConsole
{
    /// <summary>
    /// Like Console, but my version and better :)
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Prints a message to the console with no enter.
        /// </summary>
        /// <param name="message"></param>
        public static void Print(string message)
        {
            Console.Write(message);
        }
        
        /// <summary>
        /// Prints a message with color.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Print(message);
            Console.ResetColor();
        }
        
        /// <summary>
        /// Prints a message with sexy color.
        /// </summary>
        /// <param name="sexyMessage"></param>
        public static void PrintSexy(string sexyMessage)
        {
            Print(sexyMessage, ConsoleColor.DarkMagenta);
        }
        
        /// <summary>
        /// Prints gray message.
        /// </summary>
        /// <param name="sexyMessage"></param>
        public static void PrintGray(string sexyMessage)
        {
            Print(sexyMessage, ConsoleColor.Gray);
        }

        /// <summary>
        /// Prints a message to the console with enter.
        /// </summary>
        /// <param name="message"></param>
        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
        
        /// <summary>
        /// Prints a message in color.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void PrintLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            PrintLine(message);
            Console.ResetColor();
            Print("");
        }

        /// <summary>
        /// Prints a message in sexy color.
        /// </summary>
        /// <param name="sexyMessage"></param>
        public static void PrintLineSexy(string sexyMessage)
        {
            PrintLine(sexyMessage, ConsoleColor.DarkMagenta);
        }

        /// <summary>
        /// Prints a message in error color.
        /// </summary>
        /// <param name="message"></param>
        public static void PrintLineError(string message)
        {
            PrintLine(message, ConsoleColor.Red);
        }
        
        /// <summary>
        /// Prints a contrasted message.
        /// </summary>
        /// <param name="sexyMessage"></param>
        public static void PrintLineContrast(string sexyMessage)
        {
            PrintLine(sexyMessage, ConsoleColor.Blue);
        }
        
        /// <summary>
        /// Prints a gray message.
        /// </summary>
        /// <param name="sexyMessage"></param>
        public static void PrintLineGray(string sexyMessage)
        {
            PrintLine(sexyMessage, ConsoleColor.Gray);
        }

        /// <summary>
        /// Just prints a new line.
        /// </summary>
        public static void NewLine()
        {
            PrintLine("");
        }

        /// <summary>
        /// Duplicate of Console.ReadLine();
        /// </summary>
        /// <returns></returns>
        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}