namespace MediaServerManagement
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Extension class for encryption based on an algorithm described in https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
    /// </summary>
    public static class BaseEncryptionRijndaelManaged
    {
        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(this string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            byte[] saltStringBytes = Generate256BitsOfRandomEntropy();
            byte[] ivStringBytes = Generate128BitsOfRandomEntropy();
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(32);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.KeySize = 256;
                    symmetricKey.BlockSize = 128;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();

                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// decrypts a string
        /// </summary>
        /// <param name="cipherText">encrypted string</param>
        /// <param name="passPhrase">encryption key</param>
        /// <returns></returns>
        public static string Decrypt(this string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [16 bytes of IV] + [n bytes of CipherText]
            byte[] cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);

            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            byte[] saltStringBytes = cipherTextBytesWithSaltAndIv.Take(32).ToArray();

            // Get the IV bytes by extracting the next 16 bytes from the supplied cipherText bytes.
            byte[] ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(32).Take(16).ToArray();

            // Get the actual cipher text bytes by removing the first 48 bytes from the cipherText string.
            byte[] cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip(48).Take(cipherTextBytesWithSaltAndIv.Length - 48).ToArray();

            using (Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(32);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.KeySize = 256;
                    symmetricKey.BlockSize = 128;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// generates 16 bytes or 128 bit entropy
        /// </summary>
        /// <returns>random 16 bytes or 128 bit entropy</returns>
        private static byte[] Generate128BitsOfRandomEntropy()
        {
            byte[] randomBytes = new byte[16];

            RandomNumberGenerator.Fill(randomBytes);

            return randomBytes;
        }

        /// <summary>
        /// generates 32 bytes or 256 bit entropy
        /// </summary>
        /// <returns>random 32 bytes or 256 bit entropy</returns>
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            byte[] randomBytes = new byte[32];

            RandomNumberGenerator.Fill(randomBytes);
            
            return randomBytes;
        }
    }
}
