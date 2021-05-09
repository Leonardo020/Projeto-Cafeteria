using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Login
    {
        [Display(Name = "Código do Login")]
        public int codLogin { get; set; }
        [Display(Name = "Nome")]
        public string nomeLogin { get; set; }
        [Display(Name = "E-mail")]
        public string emailLogin { get; set; }
        [Display(Name = "Senha")]
        public string senhaLogin { get; set; }
        [Display(Name = "Nível")]
        public int nivelLogin { get; set; }
    }
}