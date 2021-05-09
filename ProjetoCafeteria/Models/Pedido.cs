using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Pedido
    {
        [Key]
        public Guid codItemPedido { get; set; }
        public int codVenda { get; set; }
        public int qtdItem { get; set; }
        public string produto { get; set; }
        public double valorProd { get; set; }
        public double valorPedido { get; set; }
        public int codProduto { get; set; }
    }
}