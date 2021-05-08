using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Cliente
    {
        public int codCliente { get; set; }
        public string nomeCliente { get; set; }
        public string cpfCliente { get; set; }
        public string emailCliente { get; set; }
    }
}