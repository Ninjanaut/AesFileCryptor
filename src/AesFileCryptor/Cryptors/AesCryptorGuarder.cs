using System;
using System.IO;

namespace AesFileCryptor.Cryptors
{
    public static class AesCryptorGuarder
    {
        public static void GuardKeys(byte[] key, byte[] initializationVector)
        {
            if (key == null || initializationVector == null)
            {
                Console.WriteLine("Error happens:\n");
                Console.WriteLine("Failed to process key file.\n");
            }
        }
    }
}
