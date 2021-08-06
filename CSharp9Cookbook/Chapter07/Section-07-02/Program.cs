using System;
using System.Security.Cryptography;

namespace Section_07_02
{
    class Program
    {
        static void Main()
        {
            var crypto = new Crypto();

            Console.Write("Please enter text to encrypt: ");
            string userPlainText = Console.ReadLine();

            byte[] key = GenerateKey();

            byte[] cypherBytes = crypto.Encrypt(userPlainText, key);

            string cypherText = Convert.ToBase64String(cypherBytes);

            Console.WriteLine($"Cypher Text: {cypherText}");

            string decryptedPlainText = crypto.Decrypt(cypherBytes, key);

            Console.WriteLine($"Plain Text: {decryptedPlainText}");
        }

        static byte[] GenerateKey()
        {
            const int KeyLength = 32;

            byte[] key = new byte[KeyLength];
            var rngRand = new RNGCryptoServiceProvider();

            rngRand.GetBytes(key);

            return key;
        }
    }
}
