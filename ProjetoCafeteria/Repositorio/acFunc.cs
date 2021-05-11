using MySql.Data.MySqlClient;
using ProjetoCafeteria.Models;
using ProjetoCafeteria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Repositório
{
    public class acFunc
    {
        Conexao cn = new Conexao();

        public void cadastraFunc(Funcionario func)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirFuncionario(@nome, @cpf, @email, @senha);", cn.abrirConexao());

            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = func.nomeFunc;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = func.cpfFunc;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = func.emailFunc;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = func.senhaFunc;

            cmd.ExecuteNonQuery();

            cn.fecharConexao();
        }

        public List<Funcionario> consultaFunc()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            MySqlCommand cmd = new MySqlCommand("select * from Funcionario", cn.abrirConexao());
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                funcionarios.Add(
                    new Funcionario
                    {
                        codFunc = Convert.ToInt32(dr["cod_func"]),
                        nomeFunc = dr["nome_func"].ToString(),
                        cpfFunc = dr["cpf_func"].ToString(),
                        emailFunc = dr["email_func"].ToString(),
                        senhaFunc = dr["senha_func"].ToString(),
                    }
                );
            }

            cn.fecharConexao();
            return funcionarios;
        }
    }
}