using MySql.Data.MySqlClient;
using ProjetoCafeteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Repositorio
{
    public class acLogin
    {
        Conexao cn = new Conexao();

        public void validaLogin(Login login)
        {

            MySqlCommand cmd = new MySqlCommand("select * from Login where email_login = @email and senha_login = @senha", cn.abrirConexao());
            cmd.Parameters.AddWithValue("@email", login.emailLogin);
            cmd.Parameters.AddWithValue("@senha", login.senhaLogin);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    login.nomeLogin = dr["nome_login"].ToString();
                    login.emailLogin = dr["email_login"].ToString();
                    login.senhaLogin = dr["senha_login"].ToString();
                    login.nivelLogin = Convert.ToInt32(dr["nivel_login"]);
                }
            }

            else{
                login.nomeLogin = null;
                login.emailLogin = null;
                login.senhaLogin = null;
                login.nivelLogin = Convert.ToInt32(null);
            }

            cn.fecharConexao();
        }
    }
}