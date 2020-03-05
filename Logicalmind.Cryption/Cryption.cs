using System;
using System.Security.Cryptography;
using System.Text;

namespace Logicalmind.Cryption
{
    public class Cryption : ICryption
    {
        private readonly byte[] key;
        private readonly Encoding encoding;

        public Cryption(string keyPhrase)
        {
            encoding = Encoding.UTF8;
            key = ComputeSha256Hash(keyPhrase);
        }

        public string Decrypt(string value)
        {
            var items = value.Split('.');

            if (items.Length != 2) throw new ArgumentException("Invalid Input", nameof(value));

            using (var aes = Aes.Create())
            {
                var iv = Convert.FromBase64String(items[0]);
                using (var decryptor = aes.CreateDecryptor(key, iv))
                {
                    var encryptedBytes = Convert.FromBase64String(items[1]);
                    var textBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                    return encoding.GetString(textBytes);
                }
            }
        }

        public string Encrypt(string value)
        {
            using (var rng = new RNGCryptoServiceProvider())
            using (var aes = Aes.Create())
            {
                var iv = new byte[16];
                rng.GetBytes(iv);
                using (var encryptor = aes.CreateEncryptor(key, iv))
                {
                    var textBytes = encoding.GetBytes(value);
                    var encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);

                    return $"{Convert.ToBase64String(iv)}.{Convert.ToBase64String(encryptedBytes)}";
                }
            }
        }

        private byte[] ComputeSha256Hash(string rawData)
        {
            using (var sha256Hash = SHA256.Create())
            {
                return sha256Hash.ComputeHash(encoding.GetBytes(rawData));
            }
        }
    }
}
