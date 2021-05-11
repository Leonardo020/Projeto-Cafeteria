using ProjetoCafeteria.Models;
using ProjetoCafeteria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoCafeteria.Controllers
{
    public class ClienteController : Controller
    {
        acCli acC = new acCli();

        public ActionResult cadCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cadCliente(Cliente cli)
        {
            acC.cadastraCliente(cli);
            return View();
        }

        public ActionResult consultaCliente()
        {
            var clientes = acC.consultaCliente();
            return View(clientes);
        }
    }
}