using MySql.Data.MySqlClient;
using ProjetoCafeteria.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Produto
    {
        [Display(Name = "Código do Produto")]
        public int codProduto { get; set; }
        [Display(Name = "Nome do Produto")]
        public string nomeProduto { get; set; }
        [Display(Name = "Quantidade do Produto")]
        public int qtdProduto { get; set; }
        [Display(Name = "Valor unitário")]
        public double valorProduto { get; set; }
        [Display(Name = "Código do Fornecedor")]
        public int codFornecedor { get; set; }
        [Display(Name = "Nome do Fornecedor")]
        public string nomeFornecedor { get; set; }
    }
}