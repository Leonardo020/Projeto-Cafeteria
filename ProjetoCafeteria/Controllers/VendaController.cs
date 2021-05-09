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
    public class VendaController : Controller
    {
        Conexao cn = new Conexao();

        Venda carrinho = new Venda();
        Produto prod = new Produto();
        Pedido itemPedido = new Pedido();

        acProduto acP = new acProduto();
        acVenda acV = new acVenda();
        acItemVenda acIV = new acItemVenda();

        List<SelectListItem> clientes = new List<SelectListItem>();
        List<SelectListItem> pagamentos = new List<SelectListItem>();

        void carregaClientes()
        {
            MySqlCommand cmd = new MySqlCommand("select * from cliente;", cn.abrirConexao());
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                clientes.Add(new SelectListItem
                {
                    Text = dr[1].ToString(),
                    Value = dr[0].ToString(),
                });
            }

            cn.fecharConexao();
            ViewBag.clientes = new SelectList(clientes, "Value", "Text");

        } 
        void carregaPagamentos()
        {
            MySqlCommand cmd = new MySqlCommand("select * from pagamento;", cn.abrirConexao());
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                pagamentos.Add(new SelectListItem
                {
                    Text = dr[1].ToString(),
                    Value = dr[0].ToString(),
                });
            }

            cn.fecharConexao();
            ViewBag.pagamentos = new SelectList(pagamentos, "Value", "Text");

        }
        // GET: Venda
        public ActionResult adicionarPedido(int id)
        {
            carrinho = Session["Carrinho"] != null ? (Venda)Session["Carrinho"] : new Venda();
            var produto = acP.consultaProdutoPorId(id);

            var qtdTotal = itemPedido.qtdItem;

            if (produto != null)
            {
                itemPedido.codItemPedido = Guid.NewGuid();
                itemPedido.codProduto = id;
                itemPedido.produto = produto[0].nomeProduto;
                itemPedido.qtdItem = 1;
                itemPedido.valorProd = produto[0].valorProduto;

                List<Pedido> pedidos = carrinho.itemPedido.FindAll(p => p.produto == itemPedido.produto);

                if (pedidos.Count != 0)
                {
                    var pedido = carrinho.itemPedido.FirstOrDefault(p => p.produto == produto[0].nomeProduto);
                    pedido.qtdItem += 1;
                    itemPedido.valorPedido = itemPedido.qtdItem * itemPedido.valorProd;
                    carrinho.valorTotal += itemPedido.valorPedido;
                    pedido.valorPedido = pedido.qtdItem * itemPedido.valorProd;
                    qtdTotal += pedido.qtdItem;
                    qtdTotal += carrinho.itemPedido.Count;

                }

                else
                {
                    itemPedido.valorPedido = itemPedido.qtdItem * itemPedido.valorProd;
                    carrinho.valorTotal += itemPedido.valorPedido;
                    carrinho.itemPedido.Add(itemPedido);
                    qtdTotal += itemPedido.qtdItem;
                    qtdTotal += carrinho.itemPedido.Count;

                }


                Session["Carrinho"] = carrinho;
                Session["qtdCarrinho"] = qtdTotal;
            }

            return RedirectToAction("Pedidos");
        }

        public ActionResult Pedidos()
        {
            carregaClientes();
            carregaPagamentos();
            carrinho = Session["Carrinho"] != null ? (Venda)Session["Carrinho"] : new Venda();
            return View(carrinho);
        }

        public ActionResult ExcluirItem(Guid id)
        {
            carrinho = Session["Carrinho"] != null ? (Venda)Session["Carrinho"] : new Venda();
            var itemExclusao = carrinho.itemPedido.FirstOrDefault(i => i.codItemPedido == id);

            carrinho.valorTotal -= itemExclusao.valorPedido;

            carrinho.itemPedido.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;

            return RedirectToAction("Carrinho");
        }

        public ActionResult SalvarVenda(Venda venda)
        {
            if ((Session["email"] == null || Session["senha"] == null))
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {
                var carrinho = Session["Carrinho"] != null ? (Venda)Session["Carrinho"] : new Venda();

                venda.dataVenda = DateTime.Now.ToLocalTime();
                venda.codCli = Convert.ToInt32(Request["clientes"]);
                venda.codPagamento = Convert.ToInt32(Request["pagamentos"]);
                venda.qtdVenda = Convert.ToInt32(Session["qtdCarrinho"]);
                venda.valorTotal = carrinho.valorTotal;

                acV.inserirVenda(venda);

                acV.consultaVendaPorId(venda);

                for(int i = 0; i < carrinho.itemPedido.Count; i++)
                {
                    itemPedido.codVenda = venda.codVenda;
                    itemPedido.codProduto = carrinho.itemPedido[i].codProduto;
                    itemPedido.qtdItem = carrinho.itemPedido[i].qtdItem;
                    itemPedido.valorPedido = carrinho.itemPedido[i].valorProd;
                    acIV.inserirPedido(itemPedido);
                }

                carrinho.valorTotal = 0;
                carrinho.itemPedido.Clear();

                return RedirectToAction("confVenda");

            }


        }
    }
}