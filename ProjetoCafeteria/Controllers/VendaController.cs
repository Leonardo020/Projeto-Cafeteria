using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoCafeteria.Controllers
{
    public class VendaController : Controller
    {
        // GET: Venda
        public ActionResult Pedido()
        {
            return View();
        }
    }
}