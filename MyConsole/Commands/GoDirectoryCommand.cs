using System;
using System.IO;

namespace MyConsole
{
    /// <summary>
    /// Goes to dir user specified, also u can go multiple dirs by using slashes
    /// and go upper by using ..
    /// </summary>
    public class GoDirectoryCommand : CommandBase
    {
        public GoDirectoryCommand(WorkingDirectoryContainer d) : base(d) { }

        protected override string CommandName => "cd";

        protected override string CommandDescription =>
            "<dir> - go to directory. Also you can use \"/\" to go multiple folders at once.";
        
        protected override void Action(string[] args)
        {
            WorkingDirectory.AddPath(args[0]);
        }
    }
}