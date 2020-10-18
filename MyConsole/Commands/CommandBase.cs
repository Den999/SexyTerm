using System;
using System.Drawing;
using System.IO;

namespace MyConsole
{
    /// <summary>
    /// Base class of commands. Command is something which has name, description
    /// and action which executes if it call. Also some arguments can be passed to command.
    /// </summary>
    public abstract class CommandBase
    {
        /// <summary>
        /// Now max number of arguments is this. But u can extend it whatever u like. 
        /// </summary>
        private const int MaxArgumentNumber = 10;
        
        /// <summary>
        /// Name of command, by this name user call it.
        /// </summary>
        protected abstract string CommandName { get; }
        
        /// <summary>
        /// Some info about what the command does and which parameters it has.
        /// This info will be displayed in help.
        /// </summary>
        protected abstract string CommandDescription { get; }

        /// <summary>
        /// Reference to working dir container
        /// </summary>
        protected WorkingDirectoryContainer WorkingDirectory { get; }

        protected CommandBase(WorkingDirectoryContainer d)
        {
            WorkingDirectory = d;
        }

        /// <summary>
        /// Check if command called in line user typed => execute action giving it args.
        /// </summary>
        /// <param name="line">Line which user typed.</param>
        /// <returns>Is command call exists in this line.</returns>
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

        /// <summary>
        /// Prints info about this command in list format 
        /// </summary>
        /// <param name="numberInList">Index in list</param>
        public void PrintDescription(int numberInList)
        {
            var description = $"{CommandName} {CommandDescription}";

            Log.PrintGray($"{numberInList}) ");
            Log.PrintLine(description);
        }
        
        /// <summary>
        /// What actually command does when call.
        /// </summary>
        /// <param name="args">These args command can use to specify something.</param>
        protected abstract void Action(string[] args);

        /// <summary>
        /// Splits a line to arguments array. Also fill it with empty strings
        /// to tend array be fixed length.
        /// </summary>
        /// <param name="line">String to parse.</param>
        /// <returns>Parsed arguments.</returns>
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