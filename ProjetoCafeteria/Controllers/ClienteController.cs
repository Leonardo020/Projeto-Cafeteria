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
            ViewBag.sucesso = "Cadastro realizado com sucesso!!";
            acC.cadastraCliente(cli);
            return View();
        }

        public ActionResult consultaCliente()
        {
            if ((Session["email"] == null) || (Session["senha"] == null))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var clientes = acC.consultaCliente();
                return View(clientes);
            }
        }
    }
}