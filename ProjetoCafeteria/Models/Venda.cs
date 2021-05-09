using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Venda
    {
        public int codVenda { get; set; }
        public DateTime dataVenda { get; set; }
        [Display(Name = "Quantidade venda")]
        public int qtdVenda { get; set; }
        public double valorTotal { get; set; }
        [Display(Name = "Código do Cliente")]
        public int codCli { get; set; }
        [Display(Name = "Código do Pagamentos")]
        public int codPagamento { get; set; }
        [Display(Name = "Valor unitário")]
        public int valorParcial { get; set; }
        [Display(Name="Nome do produto")]
        public string nomeProduto { get; set; }

        public List<Pedido> itemPedido = new List<Pedido>();
    }
}