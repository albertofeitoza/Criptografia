using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apis.Criptografia
{
    public class KeyConfigurations
    {
        /// <summary>     
        /// Base 64 (Chave Interna)         
        /// A chave é "Criptografias com Rijndael / AES"     
        /// </summary> 
        public string CryptoKey { get; set; }

        /// <summary>
        /// 16 bytes
        /// Ex: byte[] bIV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };
        /// </summary>
        public string BIV { get; set; }
    }
}
