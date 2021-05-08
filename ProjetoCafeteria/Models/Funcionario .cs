using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Funcionario
    {
        public int codFunc { get; set; }
        public string nomeFunc { get; set; }
        public string cpfFunc { get; set; }
        public string emailFunc { get; set; }
        public string senhaFunc { get; set; }
    }
}