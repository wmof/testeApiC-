using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleAppTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            string resposta;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://wmof.com.br/api/produto/read1.php");
            request.Method = "GET";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                resposta = reader.ReadToEnd();
            }
        
            List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(resposta);

            Console.WriteLine(resposta);
        }
    }
    class Produto
    {
        public int id;

        public string nome;

        public string descricao;

        public string categoria;

        public string subcategoria;

        public double valor;

        public string img;

        public string estabelecimento_id;

        public string estoque;
    }
}
