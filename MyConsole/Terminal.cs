using System;
using System.Collections.Generic;
using System.IO;

namespace MyConsole
{
    /// <summary>
    /// Terminal with its supported commands. You can create instances of it (sessions)
    /// and setup whenever you want
    /// </summary>
    public class Terminal
    {
        /// <summary>
        /// Terminal sign before command
        /// </summary>
        private const string EnterPrefix = "$";
        
        /// <summary>
        /// Exit command name
        /// </summary>
        private const string ExitKeyword = "exit";

        /// <summary>
        /// All commands of terminal
        /// </summary>
        private List<CommandBase> _supportedCommands;
        
        /// <summary>
        /// Working directory - there is user now. All commands works relative to this path.
        /// This path will be displayed before terminal sing (🤜)
        /// </summary>
        private WorkingDirectoryContainer _workingDirectory;

        /// <summary>
        /// Starts terminal. Setup terminal read command cycle
        /// </summary>
        public void Setup()
        {
            _workingDirectory = new WorkingDirectoryContainer();

            // Fill the list of supported commands by this terminal 
            var helpCommand = new HelpCommand(_workingDirectory);
            _supportedCommands = new List<CommandBase>
            {
                new ListViewCommand(_workingDirectory),
                new DrivesCommand(_workingDirectory),
                new GoDirectoryCommand(_workingDirectory),
                new ViewFileCommand(_workingDirectory),
                new CreateTextFileCommand(_workingDirectory),
                new RemoveFileCommand(_workingDirectory),
                new RemoveFolderCommand(_workingDirectory),
                new CopyFileCommand(_workingDirectory),
                new MoveFileCommand(_workingDirectory),
                new CombineFileContentsCommand(_workingDirectory),
                helpCommand,
            };
            // Pass the whole list of supported commands to help command
            // and help command will work with them. 
            helpCommand.Init(_supportedCommands);

            Cycle();
        }

        /// <summary>
        /// Read command cycle
        /// </summary>
        private void Cycle()
        {
            PrintPrefix();

            var line = Log.ReadLine();
            var indexOfExitCommand = line.IndexOf(ExitKeyword);
            // If no exit command typed check current line for command calls
            // otherwise log error
            if (indexOfExitCommand == -1)
            {
                bool anyCommandWasCalled = false;
                foreach (CommandBase c in _supportedCommands)
                    anyCommandWasCalled = anyCommandWasCalled|| c.CheckIfCalled(line);

                if (!anyCommandWasCalled)
                    Log.PrintLineError("Command not found!");

                Cycle();
            }
        }

        /// <summary>
        /// Print a message before user type the command. Basically contains just a info about
        /// current working dir and terminal suffix (to separate commands)
        /// </summary>
        private void PrintPrefix()
        {
            Log.Print($"{_workingDirectory.Directory.FullName} ");
            Log.PrintSexy($"{EnterPrefix} ");
        }
    }
}