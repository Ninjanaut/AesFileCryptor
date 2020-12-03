namespace AesFileCryptor.Cryptors
{
    public class AesEncryptionOutput
    {
        public byte[] Key { get; set; }
        public byte[] InitializationVector { get; set; }
        public byte[] Data { get; set; }
    }
}
