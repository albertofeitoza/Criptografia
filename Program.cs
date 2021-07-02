using Apis.Criptografia;
using Apis.Model;
using Lucene.Net.Support;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Cryptography = Apis.Criptografia.Cryptography;

namespace Apis
{
    public class Program
    {




        static void Main(string[] args)
        {
                var cryptography = new Cryptography();
                string Dados = string.Empty;
                //string url = "https://api-dominios-dev.pixeon.cloud/api/Dominio/GetAll"; // dev
                string url = "https://dominios-korus.pixeon.cloud/api/Dominio/GetAll"; // Prd
                List<DominioModel> response = new List<DominioModel>();

                using (HttpClient request = new HttpClient())
                {
                    var data = Encoding.ASCII.GetBytes("dominio-admin" + ":" + "oP5c*E9w#z0qY9xD3k");
                    request.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(data));

                    var retorno = request.GetAsync(url).Result;
                    response = JsonConvert.DeserializeObject<List<DominioModel>>(retorno.Content.ReadAsStringAsync().Result);
                }

                if (url.Contains("https://api-dominios-dev.pixeon.cloud/api/Dominio/GetAll"))
                {
                    Dados += string.Format("Dados da API de dominio de DEV {0}", Environment.NewLine);
                    Dados += string.Format("{0}|{1}{2}", "Dominio", "ConnectionString", Environment.NewLine);

                }
                else
                {
                    Dados += string.Format("Dados da API de dominio de PRODUÇÃO {0}", Environment.NewLine);
                    Dados += string.Format("{0}|{1}{2}", "Dominio", "ConnectionString", Environment.NewLine);
                }

                foreach (var item in response)
                    Dados += string.Format("{0}|{1}{2}", item.Id, cryptography.Decrypt(item.ConnectionString), Environment.NewLine);

                StreamWriter saida = new StreamWriter("D:\\saida.csv", true, Encoding.ASCII);
                saida.Write(Dados);

                saida.Close();
 


        }
    }
}
