using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Models
{
    public class Login
    {
        public int codLogin { get; set; }
        public string nomeLogin { get; set; }
        public string emailLogin { get; set; }
        public string senhaLogin { get; set; }
        public int nivelLogin { get; set; }
    }
}