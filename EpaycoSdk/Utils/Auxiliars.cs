using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EpaycoSdk.Utils
{
    public class Auxiliars
    {
        #region Constructor
        public Auxiliars() {}

        #endregion

        #region Methods

        public string ConvertToBase64(string publicKey)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(publicKey); 
            return Convert.ToBase64String(plainTextBytes);;
        }

        public static string AESEncrypt(string text, string aesKey)
        {
            // AesCryptoServiceProvider
            byte[] IV;
            Aes aesAlg = Aes.Create();
            aesAlg.GenerateIV();
            IV = aesAlg.IV;
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes("0000000000000000");;
            aes.Key = Encoding.UTF8.GetBytes(aesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert string to byte array
            byte[] src = Encoding.UTF8.GetBytes(text);

            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // Convert byte array to Base64 strings
                var encode = Convert.ToBase64String(dest);
                return encode;
                // var plainTextBytes = Encoding.UTF8.GetBytes(encode); 
                // return Convert.ToBase64String(plainTextBytes);;
            }
        }

        public static string ConcatBodyStrings(string bodyString1, string bodyString2)
        {
            string bodySubstring1 = bodyString1.Remove(bodyString1.Length - 3);
            string bodySubstring2 = bodyString2.Substring(1);
            string concatenatedStrings = bodySubstring1 + "," + bodySubstring2;

            return concatenatedStrings;
        }
        #endregion
    }
}