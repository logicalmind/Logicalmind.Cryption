# Overview
This library wraps the AES encryption library to provide a simple interface. The interface uses strings for input and output. 

# Instantiation
When you instantiate the Cryption class you provide your passphrase. This passphrase is hashed using SHA256. 

# Encryption
When you encrypt a string, a secure IV is generated. The hashed passphrase and IV are used to encrypt the string. The IV and encrypted string are returned encoded in Base64.

# Decryption
When you decrypt a string (that was encrypted using the method above), the Base64 string is split into IV and encrypted segments. The segments are Base64 decoded. The IV and the hashed passphrase are used to decrypt the input string.

# Example
```C#
var key = "MyKey";
var unencrypted = "Some Test String";

var c = new Cryption(key);

var encrypted = c.Encrypt(unencrypted);

var decrypted = c.Decrypt(encrypted);

Assert.AreEqual(unencrypted, decrypted);
```

# Note

The security of your encrypted data is dependent on the security of your key. Where you source your key or store it is entirely up to you. This library itself does not take any precautions to secure your key in memory because the [current recommendation](https://github.com/dotnet/platform-compat/blob/master/docs/DE0001.md) is that securing data in memory is not currently supported on all platforms.

