using System;
using System.Drawing;
using System.IO;

namespace MyConsole
{
    /// <summary>
    /// Like ubuntu ls in terminal - displays a list of all folders and files of current dir
    /// or specified by user dir (arg[0]).
    /// </summary>
    public class ListViewCommand : CommandBase
    {
        public ListViewCommand(WorkingDirectoryContainer d) : base(d) { }
        
        protected override string CommandName => "ls";
        protected override string CommandDescription => "- prints list of files and folders in current directory. Also you can specify which directory to look up.";

        protected override void Action(string[] args)
        {
            // We can ls current dir or dir which user specified
            var lookUpDir = WorkingDirectory.Directory;
            if (args[0] != null)
                lookUpDir = new DirectoryInfo(WorkingDirectory.GetCombinedWith(args[0]));

            // dir which is looks up should be exist
            if (!lookUpDir.Exists)
            {
                Log.PrintLineError("Directory is not exists!");
                return;
            }
            
            var dirs = lookUpDir.GetDirectories();
            var files = lookUpDir.GetFiles();

            // Print all dirs in look up dir
            int i = 1;
            foreach (DirectoryInfo d in dirs)
            {
                Log.PrintGray($"{i}) ");
                Log.PrintLineContrast(d.Name);
                i++;
            }

            // Print all files
            foreach (FileInfo f in files)
            {
                Log.PrintGray($"{i}) ");
                Log.PrintLine(f.Name);
                i++;
            }

            // If dir to look up is empty => print hint
            if (dirs.Length + files.Length == 0)
                Log.PrintLineGray("The directory is empty.");
        }
    }
}