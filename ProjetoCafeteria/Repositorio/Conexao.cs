﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCafeteria.Repositorio
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("server=localhost ;user=root; database=dbCafeteria;password=cleber123");

        public MySqlConnection abrirConexao()
        {
            try
            {
                cn.Open();
            }

            catch (Exception e)
            {
                var msg = "não foi possível conectar pelo seguinte erro: " + e.Message;
            }

            return cn;
        }

        public MySqlConnection fecharConexao()
        {
            try
            {
                cn.Close();
            }
            catch(Exception e)
            {
                var msg = "não foi possível desconectar pelo seguinte erro: " + e.Message;
            }
            return cn;
        }
    }
}