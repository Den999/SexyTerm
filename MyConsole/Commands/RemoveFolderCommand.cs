using System;
using System.IO;

namespace MyConsole
{
    public class RemoveFolderCommand : CommandBase
    {
        public RemoveFolderCommand(WorkingDirectoryContainer d) : base(d)
        {
        }

        protected override string CommandName => "rmdir";
        protected override string CommandDescription => "<dir_name> - removes the folder and all it contents.";
        protected override void Action(string[] args)
        {
            if (args[0] == "")
            {
                Log.PrintLineError("No folder specified!");
                return;
            }
            
            var pathToDir = WorkingDirectory.GetCombinedWith(args[0]);
            if (!Directory.Exists(pathToDir))
            {
                Log.PrintLineError("Folder is not exists!");
                return;
            }
            
            try
            {
                Directory.Delete(pathToDir, true);
            }
            catch (Exception e)
            {
                Log.PrintLineError("Can`t remove the folder!");
                throw;
            }
        }
    }
}