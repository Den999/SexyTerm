using System;
using System.IO;

namespace MyConsole
{
    public class WorkingDirectoryContainer
    {
        public DirectoryInfo Directory { get; private set; }

        public string FullPath => Directory.FullName;

        public WorkingDirectoryContainer()
        {
            Directory = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory());
        }

        public string GetCombinedWith(string combiningPath)
        {
            if (combiningPath == "")
                return FullPath;
            return Path.Combine(FullPath, combiningPath);
        }

        public void SetPath(string newPath)
        {
            Directory = new DirectoryInfo(newPath);
        }

        public bool AddPath(string addingPath)
        {
            addingPath = addingPath.Trim(' ');
            var path = Path.Combine(Directory.FullName, addingPath);

            var newDir = new DirectoryInfo(path);
            if (!newDir.Exists)
            {
                Log.PrintLine("The directory is not exists!", ConsoleColor.Red);
                return false;
            }
            
            Directory = newDir;
            return true;
        }
    }
}