using System.IO;
using System.Security.Cryptography;

namespace AesFileCryptor.Cryptors
{
    public static class AesCryptor
    {
        public static AesEncryptionOutput Encrypt(byte[] data)
        {
            return PrivateEncrypt(data);
        }

        public static AesEncryptionOutput EncryptWithExistingKey(byte[] data, byte[] key, byte[] initializationVector)
        {
            return PrivateEncrypt(data, key, initializationVector);
        }

        /// <summary>
        /// Will use provided key + vector combination or it will create and use new combination.
        /// </summary>
        private static AesEncryptionOutput PrivateEncrypt(byte[] data, byte[] key = null, byte[] initializationVector = null)
        {
            bool newKey = (key == null && initializationVector == null);

            var output = new AesEncryptionOutput();

            using (Aes aes = Aes.Create())
            {
                if (newKey)
                {
                    output.Key = aes.Key;
                    output.InitializationVector = aes.IV;
                }
                else
                {
                    output.Key = key;
                    output.InitializationVector = initializationVector;
                }

                using (var encryptor = newKey ? aes.CreateEncryptor() : aes.CreateEncryptor(key, initializationVector))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    output.Data = memoryStream.ToArray();
                }
            }
            return output;
        }

        public static byte[] Decrypt(byte[] data, byte[] key, byte[] initializationVector)
        {
            byte[] output;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = initializationVector;

                using (var decryptor = aes.CreateDecryptor())
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    output = memoryStream.ToArray();
                }
            }

            return output;
        }
    }
}
