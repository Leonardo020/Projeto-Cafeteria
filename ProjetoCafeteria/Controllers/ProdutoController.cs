using MySql.Data.MySqlClient;
using ProjetoCafeteria.Models;
using ProjetoCafeteria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoCafeteria.Controllers
{
    public class ProdutoController : Controller
    {
        Conexao cn = new Conexao();
        List<SelectListItem> fornecedores = new List<SelectListItem>();
        acProduto acP = new acProduto();

        void carregarFornecedores()
        {
            MySqlCommand cmd = new MySqlCommand("select * from Fornecedor", cn.abrirConexao());
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                fornecedores.Add(
                    new SelectListItem
                    {
                        Value = dr["cod_fornecedor"].ToString(),
                        Text = dr["nome_fornecedor"].ToString(),
                    }
                );
            }

            cn.fecharConexao();
            ViewBag.fornecedores = new SelectList(fornecedores, "Value", "Text");
        }

        public ActionResult cadProduto()
        {
            carregarFornecedores();
            return View();
        }

        [HttpPost]
        public ActionResult cadProduto(Produto prod)
        {
            ViewBag.sucesso = "Cadastro realizado com sucesso!!";
            carregarFornecedores();
            prod.codFornecedor = Convert.ToInt32(Request["fornecedores"]);
            acP.cadastraProduto(prod);
            return View();
        }

        public ActionResult atualizaProduto()
        {
            return View();
        }

        [HttpPost]

        public ActionResult atualizaProduto(Produto prod)
        {
            ViewBag.sucesso = "Produto atualizado com sucesso!!";
            if (Session["nivel1"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                acP.atualizaProduto(prod);
                return View();
            }
        }

        public ActionResult excluiProduto(int Id)
        {
            if (Session["nivel1"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                acP.excluiProduto(Id);
                return View();
            }
        }

    }
}