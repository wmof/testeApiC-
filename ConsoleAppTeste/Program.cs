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

/*
 <?php
require_once ("BD_Produto.php");
require_once ("Produto.php");
$banco = new BDConexao();
$conn = $banco->getConexao();
$sql = "SELECT * FROM produto";
$result = $conn->query($sql);
$resposta = array();
$quantidade = 0;
while ($linha = mysqli_fetch_array($result)) {
	$quantidade = $quantidade+1;;
    $item=array(
    "id" => $linha["id"],
    "nome" => $linha["nome"],
    "descricao" => $linha["descricao"],
    "categoria" => $linha["categoria"],
    "subcategoria" => $linha["subcategoria"],
    "valor" => $linha["valor"],
    "img" => $linha["img"],
    "estabelecimento_id" => $linha["estabelecimento_id"],
    "estoque" => $linha["estoque"],
    ); 
    array_push($resposta, $item);
}		
http_response_code(200);
echo json_encode($resposta);
?>
*/
