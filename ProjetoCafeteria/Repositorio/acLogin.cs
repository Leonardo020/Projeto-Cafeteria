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

            MySqlCommand cmd = new MySqlCommand("select * from tbLogin where email_login = @email and senha_login = @senha", cn.abrirConexao());
            cmd.Parameters.AddWithValue("@email", login.emailLogin);
            cmd.Parameters.AddWithValue("@senha", login.senhaLogin);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    login.nomeLogin = dr["nomeLogin"].ToString();
                    login.emailLogin = dr["emailLogin"].ToString();
                    login.senhaLogin = dr["senhaLogin"].ToString();
                    login.nivelLogin = Convert.ToInt32(dr["nivelLogin"]);
                }
            }

            else{
                login.nomeUsuario = null;
                login.emailUsuario = null;
                login.senhaUsuario = null;
                login.nivelLogin = Convert.ToInt32(null);
            }




        }
    }
}