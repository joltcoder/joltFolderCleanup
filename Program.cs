using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace JoltFolderCleanup.CLI
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<string>
                (
                    "--source",
                    description: "The source directory to clean up."
                ),
                new Option<string>
                (
                    "--destination",
                    description: "The destination for cleaned files."
                )
            };

            rootCommand.Description = "JoltFolderCleanup CLI - Clean up your folders efficiently!";

            rootCommand.Handler = CommandHandler.Create<string, string>((source, destination) =>
            {
                Console.WriteLine($"Cleaning up folder: {source} to {destination}");
                // Implement cleanup logic here
            });

            return rootCommand.InvokeAsync(args).Result;
        }
    }
}