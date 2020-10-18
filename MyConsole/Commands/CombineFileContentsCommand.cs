using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MyConsole
{
    /// <summary>
    /// Combines two or move files into the output file (last argument).
    /// </summary>
    public class CombineFileContentsCommand : CommandBase
    {
        public CombineFileContentsCommand(WorkingDirectoryContainer d) : base(d) { }

        protected override string CommandName => "combine";

        protected override string CommandDescription =>
            "<file1> <file2> ... <file9> <combine_output_file> combines 2..9 all files contents into the single one";
        
        protected override void Action(string[] args)
        {
            // Minimum number of args is 3
            if (args[0] == "" || args[1] == "" || args[2] == "")
            {
                Log.PrintLineError("To few arguments. You should specify 3 or move arguments");
                return;
            }
            
            // Get full absolute paths of files user specified
            List<string> filePaths = new List<string>();
            int i = 0;
            while (i < 10 && args[i] != "")
            {
                var filePath = WorkingDirectory.GetCombinedWith(args[i]);
                filePaths.Add(filePath);
                i++;
                Log.PrintLine(i.ToString());
            }
            
            // Read all data from these files
            var lines = new List<string>();
            for (int j = 0; j < filePaths.Count-1; j++)
            {
                if (!File.Exists(filePaths[j]))
                {
                    Log.PrintLineError("Some of specified files is not exists!");
                    return;
                }
                
                try
                {
                    using (StreamReader sr = new StreamReader(filePaths[j]))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.PrintLineError("Can`t read file!");
                    throw;
                }
            }
            
            // Write all strings into output (last argument) file
            if (File.Exists(filePaths.Last()))
            {
                Log.PrintLineError("File you want to combine is already exists!");
                return;
            }
            using (StreamWriter sr = new StreamWriter(filePaths.Last()))
            {
                foreach (string l in lines)
                {
                    sr.WriteLine(l);
                }    
            }
        }
    }
}