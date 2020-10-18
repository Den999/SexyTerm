using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MyConsole
{
    public class ViewFileCommand : CommandBase
    {
        public ViewFileCommand(WorkingDirectoryContainer d) : base(d) { }

        protected override string CommandName => "cat";
        protected override string CommandDescription => "<file_name> - prints the file contents into the console. Supported encoding args: d|default (by default), utf8|utf-8, unicode, ascii";
        
        protected override void Action(string[] args)
        {
            var fileName = args[0];
            if (fileName == "")
            {
                Log.PrintLineError("You should specify file name to display!");
                return;
            }
            
            var filePath = Path.Combine(WorkingDirectory.FullPath, fileName);

            if (!File.Exists(filePath))
            {
                Log.PrintLineError("File is not exists!");
                return;
            }

            var encoding = args[1].ParseEncoding();

            try
            {
                using (StreamReader sr = new StreamReader(filePath, encoding))
                {
                    string line;
                    // Read and display lines from the file until the end of the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Log.PrintLine(line, ConsoleColor.Gray);
                    }
                }
            }
            catch (Exception e)
            {
                Log.PrintLineError("The file could not be written!");
                throw;
            }
        }
    }
}