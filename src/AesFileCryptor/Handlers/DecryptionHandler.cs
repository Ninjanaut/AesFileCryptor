using AesFileCryptor.Arguments;
using AesFileCryptor.Cryptors;
using System;
using System.IO;

namespace AesFileCryptor.Handlers
{
    public static class DecryptionHandler
    {
        public static void Decrypt(Options options, byte[] data)
        {
            string[] keyFile =
                File.ReadAllLines(options.WithKey);

            byte[] key =
                Convert.FromBase64String(keyFile[0]);

            byte[] initializationVector =
                Convert.FromBase64String(keyFile[1]);

            AesCryptorGuarder.GuardKeys(key, initializationVector);

            byte[] decryptedData = AesCryptor.Decrypt(data, key, initializationVector);

            File.WriteAllBytes(options.Output, decryptedData);
        }
    }
}
