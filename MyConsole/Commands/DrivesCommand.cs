using System;
using System.Drawing;
using System.IO;

namespace MyConsole
{
    public class DrivesCommand : CommandBase
    {
        protected override string CommandName => "drive";
        protected override string CommandDescription => "- view all disks and go to disk. Also you can specify <disk_number> to cd this disk";
        
        protected override void Action(string[] args)
        {
            var drives = DriveInfo.GetDrives();

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
            
            int i = 1;
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                Log.PrintLineContrast($"{i}) {d.Name}");
                i++;
            }
        }

        public DrivesCommand(WorkingDirectoryContainer d) : base(d)
        {
        }
    }
}