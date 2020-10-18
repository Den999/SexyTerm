using System;
using System.IO;

namespace MyConsole
{
    /// <summary>
    /// Current working directory wrapper. Contains many useful methods to work with working dir
    /// and get info about it 
    /// </summary>
    public class WorkingDirectoryContainer
    {
        /// <summary>
        /// Actually working directory (where user calls the commands)
        /// </summary>
        public DirectoryInfo Directory { get; private set; }

        /// <summary>
        /// Full path to current working dir as a string
        /// </summary>
        public string FullPath => Directory.FullName;
        
        /// <summary>
        /// By default working dir is a dir where .exe runs
        /// </summary>
        public WorkingDirectoryContainer()
        {
            Directory = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory());
        }

        /// <summary>
        /// Get the path which will be if combine working dir and path you give (combining path)
        /// </summary>
        /// <param name="combiningPath">with this path working dir path will be connected</param>
        /// <returns>path which will be after combining working dir and combiningPath</returns>
        public string GetCombinedWith(string combiningPath)
        {
            if (combiningPath == "")
                return FullPath;
            return Path.Combine(FullPath, combiningPath);
        }

        /// <summary>
        /// Sets another working dir.
        /// </summary>
        /// <param name="newPath">the new path where you want to see working dir.</param>
        public void SetPath(string newPath)
        {
            Directory = new DirectoryInfo(newPath);
        }

        /// <summary>
        /// Add path to working dir and change it.
        /// </summary>
        /// <param name="addingPath">The path u want to add to working dir.</param>
        /// <returns>is new working dir exists and was it changed.</returns>
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