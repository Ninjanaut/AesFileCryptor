using AesFileCryptor.Arguments;
using AesFileCryptor.Cryptors;
using System;
using System.IO;

namespace AesFileCryptor.Handlers
{
    public static class EncryptionHandler
    {
        public static void EncryptWithKey(Options options, byte[] data)
        {
            AesEncryptionOutput output;

            string[] keyFile =
                File.ReadAllLines(options.WithKey);

            byte[] key =
                Convert.FromBase64String(keyFile[0]);

            byte[] initializationVector =
                Convert.FromBase64String(keyFile[1]);

            AesCryptorGuarder.GuardKeys(key, initializationVector);

            output = AesCryptor.EncryptWithExistingKey(data, key, initializationVector);

            SaveEncryptedFile(options, output);
        }

        public static void EncryptWithoutKey(Options options, byte[] data)
        {
            AesEncryptionOutput output = AesCryptor.Encrypt(data);
            SaveEncryptedFile(options, output);
        }

        private static void SaveEncryptedFile(Options options, AesEncryptionOutput output)
        {
            // Save encrypted file
            File.WriteAllBytes(options.Output, output.Data);

            // Save encryption key file
            if (!string.IsNullOrEmpty(options.SaveKey))
            {
                var lines = new string[2];
                lines[0] = Convert.ToBase64String(output.Key);
                lines[1] = Convert.ToBase64String(output.InitializationVector);
                File.WriteAllLines(options.SaveKey, lines);
            }
        }
    }
}
