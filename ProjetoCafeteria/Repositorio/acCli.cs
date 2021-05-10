using MySql.Data.MySqlClient;
using ProjetoCafeteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Repositorio
{
    public class acCli
    {
        Conexao cn = new Conexao();
        public void cadastraCliente(Cliente cli)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirCliente(@nome, @cpf, @email)", cn.abrirConexao());
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cli.nomeCliente;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cli.emailCliente;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = cli.cpfCliente;

            cmd.ExecuteNonQuery();

            cn.fecharConexao();
        }

        public List<Cliente> consultaCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            MySqlCommand cmd = new MySqlCommand("select * from Cliente;", cn.abrirConexao());
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clientes.Add(
                    new Cliente
                    {
                        codCliente = Convert.ToInt32(dr["cod_cli"]),
                        nomeCliente = dr["nome_cli"].ToString(),
                        emailCliente = dr["email_cli"].ToString(),
                        cpfCliente = dr["cpf_cli"].ToString(),
                    }
                );
            }
            cn.fecharConexao();
            return clientes;
        }
    }
}