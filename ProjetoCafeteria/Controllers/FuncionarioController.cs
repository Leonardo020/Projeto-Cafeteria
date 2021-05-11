using ProjetoCafeteria.Models;
using ProjetoCafeteria.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoCafeteria.Controllers
{
    public class FuncionarioController : Controller
    {
        acFunc acF = new acFunc();
        public ActionResult cadFunc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cadFunc(Funcionario func)
        {
            acF.cadastraFunc(func);
            return View();
        }

        public ActionResult consultaFunc()
        {
            var funcionarios = acF.consultaFunc();
            return View(funcionarios);
        }
    }
}