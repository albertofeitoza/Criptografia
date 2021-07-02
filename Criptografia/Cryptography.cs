using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Apis.Criptografia
{
    public class Cryptography : ICryptography
    {
        private readonly KeyConfigurations keyConfigurations;

        public Cryptography(KeyConfigurations keyConfigurations)
        {
            this.keyConfigurations = keyConfigurations;
        }

        public Cryptography()
        {
        }

        public string Decrypt(string text)
        {
            try
            {
  
                byte[] bKey = Convert.FromBase64String("KPG6ZxGw4Ald451ld1DXzA==");
                byte[] bText = Convert.FromBase64String(text);
                byte[] bIV = new UTF8Encoding().GetBytes("HR$2pIjHR$2pIj12");

                Rijndael rijndael = new RijndaelManaged();
                rijndael.KeySize = 256;

                MemoryStream mStream = new MemoryStream();

                CryptoStream decryptor = new CryptoStream(mStream, rijndael.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write);
                decryptor.Write(bText, 0, bText.Length);
                decryptor.FlushFinalBlock();

                UTF8Encoding utf8 = new UTF8Encoding();

                return utf8.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao descriptografar", ex);
            }

        }

        public string Encrypt(string text)
        {
            try
            {

                byte[] bKey = Convert.FromBase64String("KPG6ZxGw4Ald451ld1DXzA==");
                byte[] bText = new UTF8Encoding().GetBytes(text);
                byte[] bIV = new UTF8Encoding().GetBytes("HR$2pIjHR$2pIj12");

                Rijndael rijndael = new RijndaelManaged();
                rijndael.KeySize = 256;

                MemoryStream mStream = new MemoryStream();

                CryptoStream encryptor = new CryptoStream(mStream, rijndael.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write);
                encryptor.Write(bText, 0, bText.Length);
                encryptor.FlushFinalBlock();

                return Convert.ToBase64String(mStream.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criptografar", ex);
            }
        }
    }
}
