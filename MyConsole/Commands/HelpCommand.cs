using System;
using System.Collections.Generic;
using System.IO;

namespace MyConsole
{
    public class HelpCommand : CommandBase
    {
        public HelpCommand(WorkingDirectoryContainer d) : base(d) { }
        
        protected override string CommandName => "help";
        protected override string CommandDescription => "- prints a help guide.";

        private List<CommandBase> _helpCommands;

        public void Init(List<CommandBase> helpCommands)
        {
            _helpCommands = helpCommands;
            
            Console.Clear();
            
            Log.PrintLineSexy("Welcome to SexyTerm!");
            
            Log.NewLine();
            
            Log.PrintLineContrast("Additional features:");
            Log.PrintLine("You can go on upper folder level. Just use cd ..");
            Log.PrintLine("You can copy, remove, create files from any folder. Example rm ../test.txt");
            Log.PrintLine("Also there is a feature which allows u remove a folder. Please don`t try it on your disk :))");
            Log.PrintLine("You can create file and write a string into it. Example touch me.txt d message...");
            Log.PrintLine("You can use ls with dir. Example ls code");
            
            Action(new string[]{});
        }

        protected override void Action(string[] args)
        {
            Log.NewLine();
            Log.PrintLineContrast("Usage instruction:");
            Log.PrintLine("It is works like any unix terminal.");
            Log.PrintLine("To execute a command you should type a necessary keyword and press ENTER.");
            Log.PrintLine("Also there are parameters, like <file_name>. Just write them after command keyword.");
            Log.Print("Command example #1: ");
            Log.PrintLineGray("rm code.txt");
            Log.Print("Command example #2: ");
            Log.PrintLineGray("cat interesting.txt ascii");
            Log.NewLine();
            
            Log.PrintLineContrast("List of supported commands: ");

            int i = 1;
            foreach (CommandBase c in _helpCommands)
            {
                c.PrintDescription(i);
                i++;
            }
            
            Log.NewLine();
        }
    }
}