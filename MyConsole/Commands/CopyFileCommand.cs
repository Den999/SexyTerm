using System;
using System.IO;

namespace MyConsole
{
    /// <summary>
    /// Creates a copy of file.
    /// </summary>
    public class CopyFileCommand : CommandBase
    {
        public CopyFileCommand(WorkingDirectoryContainer d) : base(d) { }

        protected override string CommandName => "cp";

        protected override string CommandDescription =>
            "<source_file> <destination_file> - creates a copy of source file.";
        protected override void Action(string[] args)
        {
            if (args[0] == "" || args[1] == "")
            {
                Log.PrintLineError("You should specify to files!");
                return;
            }

            var sourceFilePath = WorkingDirectory.GetCombinedWith(args[0]);
            var destinationFilePath = WorkingDirectory.GetCombinedWith(args[1]);

            if (!File.Exists(sourceFilePath))
            {
                Log.PrintLineError("File you specified is not exists!");
                return;
            }

            if (File.Exists((destinationFilePath)))
            {
                Log.PrintLineError("Destination file shouldn`t be exists!");
                return;
            }
            
            try
            {
                File.Copy(sourceFilePath, destinationFilePath);
            }
            catch (Exception e)
            {
                Log.PrintLineError("Can`t copy a file!");
                throw;
            }
        }
    }
}