using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Funcionario
    {
        [Display(Name = "Código do Funcionário")]
        public int codFunc { get; set; }
        [Display(Name = "Nome do Funcionário")]
        public string nomeFunc { get; set; }
        [Display(Name = "CPF do Funcionário")]
        public string cpfFunc { get; set; }
        [Display(Name = "E-mail do Funcionário")]
        public string emailFunc { get; set; }
        [Display(Name = "Senha do Funcionário")]
        public string senhaFunc { get; set; }
    }
}