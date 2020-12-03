# AesFileCryptor

Command Line utility targeting .NET Framework >= 4.6.1. Utility can encrypt or decrypt file with symmetric AES cipher. Generated key file for crypting contains AES key and initialization vector (IV). 

## Help

| Parameter | Description |
| ----------- | ----------- |
| --file  | Required. Path of the file we want to encrypt or decrypt. |
| --output  | Required. Select file path where encrypted or decrypted file will be saved.|
| --save-key  | Select file path, where newly generated symmetric key will be saved.|
| --with-key  | Select file path of existing symmetric AES key.|
| --encrypt  | Encryption is turned off, select this option if you want to encrypt.|
| --decrypt   | Decryption is turned off, select this option if you want to decrypt.|
| --help  | Display this help screen.|
| --version  | Display version information.|

## Usage examples

   Encrypt file:

       AesFileCryptor --encrypt --file file.extension --output file.extension.aes --save-key file.extension.aes.key

   Encrypt file with existing key:

       AesFileCryptor --encrypt --file file.extension --output file.extension.aes --with-key file.extension.aes.key

   Decrypt file with existing key:

       AesFileCryptor --encrypt --file file.extension.aes --output file.extension --with-key file.extension.aes.key
