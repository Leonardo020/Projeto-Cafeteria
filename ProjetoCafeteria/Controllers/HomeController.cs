using ProjetoCafeteria.Models;
using ProjetoCafeteria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoCafeteria.Controllers
{
    public class HomeController : Controller
    {
        Conexao cn = new Conexao();
        acLogin acL = new acLogin();
        acProduto acP = new acProduto();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            acL.validaLogin(login);
            if (login.emailLogin != null && login.senhaLogin != null)
            {
                FormsAuthentication.SetAuthCookie(login.emailLogin, false);
                Session["nome"] = login.nomeLogin.ToString();
                Session["email"] = login.emailLogin.ToString();
                Session["senha"] = login.senhaLogin.ToString();

                if (login.nivelLogin == 1)
                {
                    Session["nivel1"] = login.nivelLogin.ToString();
                }

                else
                {
                    Session["nivel2"] = login.nivelLogin.ToString();
                }
                return RedirectToAction("Home");
            }
            ViewBag.Message = "Senha ou usuário incorretos";
            return View();
        }

        public ActionResult Home()
        {
            var produtos = acP.consultaProduto();
            return View(produtos);
        }
    }
}