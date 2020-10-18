using System;
using System.IO;

namespace MyConsole
{
    public class RemoveFileCommand : CommandBase
    {
        public RemoveFileCommand(WorkingDirectoryContainer d) : base(d)
        {
        }

        protected override string CommandName => "rm";
        protected override string CommandDescription => "<file_name> - removes the file.";
        protected override void Action(string[] args)
        {
            if (args[0] == "")
            {
                Log.PrintLineError("No file specified!");
                return;
            }
            
            var pathToFile = WorkingDirectory.GetCombinedWith(args[0]);
            if (!File.Exists(pathToFile))
            {
                Log.PrintLineError("File is not exists!");
                return;
            }
            
            try
            {
                File.Delete(pathToFile);
            }
            catch (Exception e)
            {
                Log.PrintLineError("Can`t remove the file!");
                throw;
            }
        }
    }
}