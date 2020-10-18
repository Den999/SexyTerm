using System;
using System.IO;
using System.Text;

namespace MyConsole
{
    /// <summary>
    /// Creates a new text file. Also u can specify encoding
    /// and message to write into file (2, 3 args)
    /// </summary>
    public class CreateTextFileCommand : CommandBase
    {
        public CreateTextFileCommand(WorkingDirectoryContainer d) : base(d) { }

        protected override string CommandName => "touch";
        protected override string CommandDescription => "<file_name> - create a text file. Supported encoding args: d|default (by default), utf8|utf-8, unicode, ascii";

        protected override void Action(string[] args)
        {
            // Minimum number of args is 1
            if (args[0] == "")
            {
                Log.PrintLineError("You should specify file name!");
                return;
            }
            
            // Get full path of file to create
            var fileName = args[0];
            var path = Path.Combine(WorkingDirectory.FullPath, fileName);

            // Parse encoding and message if it exists
            var encoding = args[1].ParseEncoding();
            var message = args[2];

            try
            {
                using (StreamWriter sr = new StreamWriter(path, true, encoding))
                    sr.WriteLine(message);
            }
            catch (Exception e)
            {
                Log.PrintLineError("The file could not be writen!");
                throw;
            }
        }
    }
}