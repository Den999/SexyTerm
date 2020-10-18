using System;
using System.IO;

namespace MyConsole
{
    public class MoveFileCommand : CommandBase
    {
        public MoveFileCommand(WorkingDirectoryContainer d) : base(d) { }

        protected override string CommandName => "mv";

        protected override string CommandDescription =>
            "<file_to_move> <destination_folder> - move a file into a folder.";
        protected override void Action(string[] args)
        {
            if (args[0] == "" || args[1] == "")
            {
                Log.PrintLineError("You should specify source and destination!");
                return;
            }

            var sourceFilePath = WorkingDirectory.GetCombinedWith(args[0]);
            var destinationFolderPath = WorkingDirectory.GetCombinedWith(args[1]);
            var destinationFilePath = Path.Combine(destinationFolderPath, args[0]);
            
            if (!File.Exists(sourceFilePath))
            {
                Log.PrintLineError("File to move is not exists!");
                return;
            }

            if (!Directory.Exists((destinationFolderPath)))
            {
                Log.PrintLineError("Destination folder is not exists!");
                return;
            }

            if (File.Exists(destinationFilePath))
            {
                Log.PrintLineError("There is already same file in directory you trying to move!");
                return;
            }
            
            try
            {
                File.Move(sourceFilePath, destinationFilePath);
            }
            catch (Exception e)
            {
                Log.PrintLineError("Can`t move a file!");
                throw;
            }
        }
    }
}