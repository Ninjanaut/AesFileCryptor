using AesFileCryptor.Arguments;
using AesFileCryptor.Handlers;
using System;
using System.IO;

namespace AesFileCryptor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = OptionsParser.ParseArgumentsOrDisplayHelpScreen(args);

            byte[] dataToEncryptOrDecrypt = File.ReadAllBytes(options.File);

            if (options.Encrypt)
            {
                if (string.IsNullOrEmpty(options.WithKey))
                {
                    EncryptionHandler.EncryptWithoutKey(options, dataToEncryptOrDecrypt);
                }
                else
                {
                    EncryptionHandler.EncryptWithKey(options, dataToEncryptOrDecrypt);
                }
                Console.WriteLine("Encryption was successful");
            }
            else if (options.Decrypt)
            {
                DecryptionHandler.Decrypt(options, dataToEncryptOrDecrypt);
                Console.WriteLine("Decryption was successful");
            }
        }
    }
}
