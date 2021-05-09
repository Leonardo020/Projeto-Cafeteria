using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Cliente
    {
        [Display(Name="Código do Cliente")]
        public int codCliente { get; set; }
        [Display(Name = "Nome do Cliente")]
        public string nomeCliente { get; set;}
        [Display(Name = "CPF do Cliente")]
        public string cpfCliente { get; set; }
        [Display(Name = "E-mail do Cliente")]
        public string emailCliente { get; set; }
    }
}