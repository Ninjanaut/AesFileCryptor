using CommandLine;

namespace AesFileCryptor.Arguments
{
    public class Options
    {
        [Option(Required = true, HelpText = "Path of the file we want to encrypt or decrypt.")]
        public string File { get; set; }

        [Option(Required = true, HelpText = "Select file path where encrypted or decrypted file will be saved.")]
        public string Output { get; set; }

        [Option("save-key", HelpText = "Select file path, where newly generated symmetric key will be saved.")]
        public string SaveKey { get; set; }

        [Option("with-key", HelpText = "Select file path of existing symmetric AES key.")]
        public string WithKey { get; set; }

        [Option("encrypt", HelpText = "Encryption is turned off, select this option if you want to encrypt.")]
        public bool Encrypt { get; set; }

        [Option("decrypt", HelpText = "Decryption is turned off, select this option if you want to decrypt.")]
        public bool Decrypt { get; set; }
    }
}