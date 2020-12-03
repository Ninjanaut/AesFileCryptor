using System.IO;
using System.Linq;
using Xunit;

namespace AesFileCryptor.Tests
{
    public class ProgramTest
    {
        readonly string testFilesDir = @"..\..\..\TestTools\TestFiles\";

        [Fact]
        public void EncryptAndDecryptFile()
        {
            // Arrange 
            var originalFile = Path.Combine(testFilesDir, "test.txt");

            Assert.True(File.Exists(originalFile));

            var key = Path.Combine(testFilesDir, "aes.key");
            var encryptedFile = Path.Combine(testFilesDir, "test.txt.encrypted");
            var decryptedFile = Path.Combine(testFilesDir, "test.decrypted.txt");

            // Act: encryption
            var command = $"--encrypt --file {originalFile} --output {encryptedFile} --save-key {key}";
            Program.Main(command.Split(" "));

            // Act: decryption
            command = $"--decrypt --file {encryptedFile} --output {decryptedFile} --with-key {key}";
            Program.Main(command.Split(" "));

            // Assert
            Assert.True(File.Exists(encryptedFile));
            Assert.True(File.Exists(key));
            Assert.True(File.Exists(decryptedFile));
            Assert.Equal("Hello World!", File.ReadLines(decryptedFile).First());

            // Cleanup
            File.Delete(encryptedFile);
            File.Delete(key);
            File.Delete(decryptedFile);
        }

        [Fact]
        public void EncryptAndDecryptFileWithExistingKey()
        {
            // Arrange 
            var originalFile = Path.Combine(testFilesDir, "test.txt");
            var key = Path.Combine(testFilesDir, "provided.aes.key");

            Assert.True(File.Exists(originalFile));
            Assert.True(File.Exists(key));

            var encryptedFile = Path.Combine(testFilesDir, "test.txt.encrypted");
            var decryptedFile = Path.Combine(testFilesDir, "test.decrypted.txt");

            // Act: encryption
            var command = $"--encrypt --file {originalFile} --output {encryptedFile} --with-key {key}";
            Program.Main(command.Split(" "));

            // Act: decryption
            command = $"--decrypt --file {encryptedFile} --output {decryptedFile} --with-key {key}";
            Program.Main(command.Split(" "));

            // Assert
            Assert.True(File.Exists(encryptedFile));
            Assert.True(File.Exists(key));
            Assert.True(File.Exists(decryptedFile));
            Assert.Equal("Hello World!", File.ReadLines(decryptedFile).First());

            // Cleanup
            File.Delete(encryptedFile);
            File.Delete(decryptedFile);
        }
    }
}
