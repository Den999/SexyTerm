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
            // Minimum number of args is 2
            if (args[0] == "" || args[1] == "")
            {
                Log.PrintLineError("You should specify to files!");
                return;
            }

            // Get full paths of "from" and "to" files
            var sourceFilePath = WorkingDirectory.GetCombinedWith(args[0]);
            var destinationFilePath = WorkingDirectory.GetCombinedWith(args[1]);

            // Source should be and output shouldn`t exist
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
            
            // Actual copying with error handling
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