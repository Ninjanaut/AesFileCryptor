using CommandLine;
using System;
using System.IO;
using System.Linq;

namespace AesFileCryptor.Arguments
{
    public static class OptionsParser
    {
        public static Options ParseArgumentsOrDisplayHelpScreen(string[] args)
        {
            var options = new Options();
            var parseError = false;

            Parser.Default
                .ParseArguments<Options>(args)
                    .WithParsed(o => { options = o; })
                    .WithNotParsed(o => { parseError = true; });

            if (args.ToList().Contains("--help") || parseError)
            {
                var help =
                "Usage examples\n\n" +
                "   Encrypt file:\n\n" +
                "       AesFileCryptor --encrypt --file file.extension --output file.extension.aes --save-key file.extension.aes.key\n\n" +
                "   Encrypt file with existing key:\n\n" +
                "       AesFileCryptor --encrypt --file file.extension --output file.extension.aes --with-key file.extension.aes.key\n\n" +
                "   Decrypt file with existing key:\n\n" +
                "       AesFileCryptor --encrypt --file file.extension.aes --output file.extension --with-key file.extension.aes.key\n\n";

                Console.WriteLine(help);
                Environment.Exit(0);
            }
            else
            {
                ValidateArguments(options);
            }

            return options;
        }
        public static void ValidateArguments(Options options)
        {
            var isError = false;

            if (options.Encrypt && options.Decrypt)
            {
                DisplayHeader();
                Console.WriteLine("Only --encrypt or --decrypt parameter can be selected, not both.\n");
            }
            if (!options.Encrypt && !options.Decrypt)
            {
                DisplayHeader();
                Console.WriteLine("You have to select --encrypt or --decrypt parameter.\n");
            }
            if (!File.Exists(options.File))
            {
                DisplayHeader();
                Console.WriteLine("Provided --file parameter is not valid.\n");
            }
            if (options.Decrypt && string.IsNullOrEmpty(options.WithKey))
            {
                DisplayHeader();
                Console.WriteLine("If --decrypt parameter is selected, --with-key parameter has to be provided.\n");
            }
            if (options.Encrypt && string.IsNullOrEmpty(options.WithKey) && string.IsNullOrEmpty(options.SaveKey))
            {
                DisplayHeader();
                Console.WriteLine("If --encrypt parameter is selected, you have to provide --with-key or --save-key parameter.\n");
            }

            if (isError) Environment.Exit(0);

            void DisplayHeader()
            {
                if (!isError)
                {
                    Console.WriteLine("Error(s) happens:\n");
                }
                isError = true;
            }
        }
    }
}
