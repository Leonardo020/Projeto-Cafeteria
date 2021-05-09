using MySql.Data.MySqlClient;
using ProjetoCafeteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Repositorio
{
    public class acItemVenda
    {
        Conexao cn = new Conexao();
        public void inserirPedido(Pedido pedido)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirPedido(@qtd, @valor, @cod_prod, @cod_venda)", cn.abrirConexao());

            cmd.Parameters.Add("@qtd", MySqlDbType.Int32).Value = pedido.qtdItem;
            cmd.Parameters.Add("@valor", MySqlDbType.Float).Value = pedido.valorPedido;
            cmd.Parameters.Add("@cod_prod", MySqlDbType.Int32).Value = pedido.codProduto;
            cmd.Parameters.Add("@cod_venda", MySqlDbType.VarChar).Value = pedido.codVenda;
            cmd.ExecuteNonQuery();
            cn.fecharConexao();
        }
    }
}