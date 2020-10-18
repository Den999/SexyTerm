using System;
using System.IO;
using System.Text;

namespace MyConsole
{
    public class CreateTextFileCommand : CommandBase
    {
        public CreateTextFileCommand(WorkingDirectoryContainer d) : base(d) { }

        protected override string CommandName => "touch";
        protected override string CommandDescription => "<file_name> - create a text file. Supported encoding args: d|default (by default), utf8|utf-8, unicode, ascii";

        protected override void Action(string[] args)
        {
            var fileName = args[0];
            var path = Path.Combine(WorkingDirectory.FullPath, fileName);

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