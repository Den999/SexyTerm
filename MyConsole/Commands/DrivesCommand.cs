using System;
using System.Drawing;
using System.IO;

namespace MyConsole
{
    /// <summary>
    /// Command which displays all drives u have in a list view.
    /// Also with arg u can cd to disk (by it number).
    /// </summary>
    public class DrivesCommand : CommandBase
    {
        public DrivesCommand(WorkingDirectoryContainer d) : base(d) { }
        
        protected override string CommandName => "drive";
        
        protected override string CommandDescription => 
            "- view all disks and go to disk. Also you can specify <disk_number> to cd this disk";
        
        protected override void Action(string[] args)
        {
            var drives = DriveInfo.GetDrives();

            // If user specify arg => cd this disk by entered number
            int diskIndex;
            if (int.TryParse(args[0], out diskIndex))
            {
                diskIndex--;
                if (diskIndex >= 0 && diskIndex < drives.Length)
                {
                    WorkingDirectory.SetPath(drives[diskIndex].Name);
                }
                else
                {
                    Log.PrintLineError("Invalid drive number!");
                    return;
                }
            }
            
            // Otherwise display all disks as list
            int i = 1;
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                Log.PrintLineContrast($"{i}) {d.Name}");
                i++;
            }
        }
    }
}