using MySql.Data.MySqlClient;
using ProjetoCafeteria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Produto
    {
        public int codProduto { get; set; }
        public string nomeProduto { get; set; }
        public int qtdProduto { get; set; }
        public double valorProduto { get; set; }
        public int codFornecedor { get; set; }
        public string nomeFornecedor { get; set; }
    }
}