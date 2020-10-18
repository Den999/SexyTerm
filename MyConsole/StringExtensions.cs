using System.Text;

namespace MyConsole
{
    public static class StringExtensions
    {
        // public static bool HasArgument(this string line, int argumentNumber)
        // {
        //     line = line.Trim();
        //     
        //     if (line == "")
        //         return false;
        //
        //     var args = line.Split();
        //     return args.Length > argumentNumber;
        // }
        //
        // public static string ExtractArgument(this string line, int argumentNumber)
        // {
        //     line = line.Trim();
        //     
        //     if (line == "")
        //         return "";
        //
        //     var args = line.Split();
        //     if (args.Length < argumentNumber)
        //         return "";
        //     
        //     return args[argumentNumber];
        // }

        public static Encoding ParseEncoding(this string line)
        {
            switch (line)
            {
                case "":
                case "default":
                case "def":
                case "d":
                    return Encoding.Default;
                case "utf-8":
                case "utf8":
                    return Encoding.UTF8;
                case "unicode":
                    return Encoding.Unicode;
                case "ascii":
                    return Encoding.ASCII;
                default:
                    Log.PrintLineError("Unknown encoding!");
                    return Encoding.Default;
            }
        }
    }
}