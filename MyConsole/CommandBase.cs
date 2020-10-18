using System;
using System.Drawing;
using System.IO;

namespace MyConsole
{
    public abstract class CommandBase
    {
        protected const int MaxArgumentNumber = 10;
        
        protected abstract string CommandName { get; }
        protected abstract string CommandDescription { get; }

        protected WorkingDirectoryContainer WorkingDirectory { get; private set; }

        protected CommandBase(WorkingDirectoryContainer d)
        {
            WorkingDirectory = d;
        }

        public bool CheckIfCalled(string line)
        {
            var command = line.Trim().Split()[0];
            var indexOfCommand = command.IndexOf(CommandName);
            
            if (indexOfCommand != -1 && command.Length == CommandName.Length)
            {
                Action(PrepareArguments(line));
                return true;
            }

            return false;
        }

        public void PrintDescription(int numberInList)
        {
            var description = $"{CommandName} {CommandDescription}";

            Log.PrintGray($"{numberInList}) ");
            Log.PrintLine(description);
        }
        
        protected abstract void Action(string[] args);

        private string[] PrepareArguments(string line)
        {
            var args = new string[MaxArgumentNumber];
            var existingArgs = line.Substring(CommandName.Length).Trim().Split();
            for (int i = 0; i < MaxArgumentNumber; i++)
                args[i] = i < existingArgs.Length ? existingArgs[i] : "";
            
            return args;
        }
    }
}