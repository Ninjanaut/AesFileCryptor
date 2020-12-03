# AesFileCryptor

Utility for encrypting and decrypting files with symmetric cipher (AES).
Requires .NET Framework >= 4.6.1.

## Help

| Parameter | Description |
| ----------- | ----------- |
| --file  | Required. Path of the file we want to encrypt or decrypt. |
| --output  | Required. Select file path where encrypted or decrypted file will be saved.|
| --save-key  | Select file path, where newly generated key will be saved.|
| --with-key  | Select file path of existing key.|
| --encrypt  | Encryption is turned off, select this option if you want to encrypt.|
| --decrypt   | Decryption is turned off, select this option if you want to decrypt.|
| --help  | Display this help screen.|
| --version  | Display version information.|

## Usage examples

   Encrypt file:

       AesFileCryptor --encrypt --file=somefile --output=encryptedfile --save-key=keyfile

   Encrypt file with existing key:

       AesFileCryptor --encrypt --file=somefile --output=encryptedfile --with-key=keyfile

   Decrypt file with existing key:

       AesFileCryptor --decrypt --file=encryptedfile --output=somefile --with-key=keyfile

## Implementation details

* Key size is 256 bits
* Mode is CBC
* Padding is PKC7

### Key file structure

Generated key file is simple textfile where 
* First line contains key in Base64 encoding
* Second line contains initialization vector in Base64 encoding