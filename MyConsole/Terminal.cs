using System;
using System.Collections.Generic;
using System.IO;

namespace MyConsole
{
    public class Terminal
    {
        private const string EnterPrefix = "🤜";
        private const string ExitKeyword = "exit";

        private List<CommandBase> _supportedCommands;
        private WorkingDirectoryContainer _workingDirectory;

        public void Setup()
        {
            _workingDirectory = new WorkingDirectoryContainer();

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
            helpCommand.Init(_supportedCommands);

            Cycle();
        }

        private void Cycle()
        {
            PrintPrefix();

            var line = Log.ReadLine();
            var indexOfExitCommand = line.IndexOf(ExitKeyword);
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

        private void PrintPrefix()
        {
            Log.Print($"{_workingDirectory.Directory.FullName} ");
            Log.PrintSexy($"{EnterPrefix} ");
        }
    }
}