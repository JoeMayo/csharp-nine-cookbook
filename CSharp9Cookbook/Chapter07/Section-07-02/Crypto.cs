using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Section_07_02
{
    public class Crypto
    {
        public byte[] Encrypt(string plainText, byte[] key)
        {
            using Aes aes = Aes.Create();
            aes.Key = key;

            using var memStream = new MemoryStream();
            memStream.Write(aes.IV, 0, aes.IV.Length);

            using var cryptoStream = new CryptoStream(
                memStream,
                aes.CreateEncryptor(),
                CryptoStreamMode.Write);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            cryptoStream.Write(plainTextBytes);
            cryptoStream.FlushFinalBlock();

            return memStream.ToArray();
        }

        public string Decrypt(byte[] cypherBytes, byte[] key)
        {
            using var memStream = new MemoryStream();
            memStream.Write(cypherBytes);
            memStream.Position = 0;

            using var aes = Aes.Create();

            byte[] iv = new byte[aes.IV.Length];
            memStream.Read(iv, 0, iv.Length);

            using var cryptoStream = new CryptoStream(
                memStream,
                aes.CreateDecryptor(key, iv),
                CryptoStreamMode.Read);

            int plainTextByteLength = cypherBytes.Length - iv.Length;
            var plainTextBytes = new byte[plainTextByteLength];
            cryptoStream.Read(plainTextBytes, 0, plainTextByteLength);

            return Encoding.UTF8.GetString(plainTextBytes);
        }
    }
}
