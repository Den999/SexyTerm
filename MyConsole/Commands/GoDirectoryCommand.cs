using System;
using System.IO;

namespace MyConsole
{
    public class GoDirectoryCommand : CommandBase
    {
        public GoDirectoryCommand(WorkingDirectoryContainer d) : base(d)
        {
        }

        protected override string CommandName => "cd";

        protected override string CommandDescription =>
            "<dir> - go to directory. Also you can use \"/\" to go multiple folders at once.";
        
        protected override void Action(string[] args)
        {
            WorkingDirectory.AddPath(args[0]);
        }
    }
}