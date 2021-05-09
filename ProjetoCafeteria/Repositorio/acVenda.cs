using MySql.Data.MySqlClient;
using ProjetoCafeteria.Models;
using System;

namespace ProjetoCafeteria.Repositorio
{
    public class acVenda
    {
        Conexao cn = new Conexao();

        public void inserirVenda(Venda venda)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirVenda(@valorTotal, @qtdVenda, @dataVenda, @codCli, @codPagamento);", cn.abrirConexao());

            cmd.Parameters.Add("@valorTotal", MySqlDbType.VarChar).Value = venda.valorTotal;
            cmd.Parameters.Add("@qtdVenda", MySqlDbType.Int32).Value = venda.qtdVenda;
            cmd.Parameters.Add("@dataVenda", MySqlDbType.VarChar).Value = venda.dataVenda;
            cmd.Parameters.Add("@codCli", MySqlDbType.Int32).Value = venda.codCli;
            cmd.Parameters.Add("@codPagamento", MySqlDbType.VarChar).Value = venda.codPagamento;
            cmd.ExecuteNonQuery();
            cn.fecharConexao();
        }

        public void consultaVendaPorId(Venda venda)
        {
            MySqlCommand cmd = new MySqlCommand("select cod_venda from Venda order by cod_venda desc limit 1", cn.abrirConexao());
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                venda.codVenda = Convert.ToInt32(dr["cod_venda"]);
            }
            cn.fecharConexao();
        }
    }
}